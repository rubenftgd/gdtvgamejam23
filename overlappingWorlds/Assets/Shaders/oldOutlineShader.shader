Shader "Outlined/Silhouetted Diffuse" {
	Properties {
		_Color ("Main Color", Color) = (.5,.5,.5,1)
		_OutlineColor ("Outline Color", Color) = (1,0.5,0,1)
		_Outline ("Outline width", Range (0.0, 0.1)) = .05
		_MainTex ("Base (RGB)", 2D) = "white" { }
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 100
	   
		Pass {
			Name "OUTLINE"
			Tags { "LightMode" = "Always" }
			Cull Off
			ZWrite Off
			ColorMask RGB

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			struct appdata {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};
			
			struct v2f {
				float4 vertex : SV_POSITION;
				float4 color : COLOR0;
			};
			
			float _Outline;
			float4 _OutlineColor;
			
			v2f vert (appdata v) {
				// just make a copy of incoming vertex data but scaled according to normal direction
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				float3 norm   = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				float2 offset = TransformViewToProjection(norm.xy);
				o.vertex.xy += offset * o.vertex.z * _Outline;
				o.color = _OutlineColor;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target {
				return i.color;
			}
			ENDCG
		}
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		fixed4 _Color;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
