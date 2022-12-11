// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "AlchemistLab/UI/Fire" {
	Properties {
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		[PerRendererData] _Color ("Tint", Color) = (1,1,1,1)

		_WaveCount ("WaveCount", Range (0, 50)) = 15
		_Frequency ("Frequency", Range (0, 4)) = 1
		_OffsetY ("OffsetY", Range (-0.1, 0.75)) = 0
		_Height ("Height", Range (0, 1.3)) = 1

		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255

		_ColorMask ("Color Mask", Float) = 15

		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
	}
	SubShader {
		Tags
		{
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="Transparent"
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}
		Stencil
		{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp]
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
		}

		Cull Off
		Lighting Off
		ZWrite Off
		ZTest [unity_GUIZTestMode]
		Blend SrcAlpha One
		ColorMask [_ColorMask]
		Pass{
			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0

			#include "UnityCG.cginc"
			#include "UnityUI.cginc"

			#pragma multi_compile __ UNITY_UI_CLIP_RECT
			#pragma multi_compile __ UNITY_UI_ALPHACLIP

			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color : COLOR;
				half2 texcoord  : TEXCOORD0;
				float4 worldPosition : TEXCOORD2;
				UNITY_VERTEX_OUTPUT_STEREO
			};
			sampler2D _MainTex;
			fixed4 _Color;

			float4 _ClipRect;
			float _offset;
			int _nX;
			int _nY;
			float _WaveCount;
			float _Frequency;
			float _OffsetY;
			float _Height;
			float _iterMin;
			float _iterMax;
			float _min;
			float _max;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.worldPosition = IN.vertex;
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);
				OUT.color = IN.color * _Color;
				return OUT;
			}

			fixed4 frag(v2f input) : SV_Target
			{
				fixed2 uv = input.texcoord;
				float koeff = uv.x;
				float time = _Time.y * _Frequency;
				uv.x = uv.x * _WaveCount + 0.2 * sin(uv.y * 3 + time * 2 ) + 0.3 * sin(uv.x * 5 + 3 * time);
				float koef = smoothstep(0.05, 0, koeff) * 5 + smoothstep(0.95, 1, koeff) * 5 + 1 + 0.35 * sin(time * 8 + uv.x * 3.5234) + 1 - 0.35 * cos(time * 5 - uv.x * 2.345) + 0.15 * cos(time * 6 - uv.x * 7.345);
				uv.x = uv.x - floor(uv.x);
				uv.y = (uv.y + _OffsetY) * koef * koef * koef * 0.7 / _Height;
				fixed4 c = tex2D(_MainTex, uv) * input.color;
				
				#ifdef UNITY_UI_CLIP_RECT
					c.a *= UnityGet2DClipping(input.worldPosition.xy, _ClipRect);// * _UseUIAlphaClip;
				#endif

			    #ifdef UNITY_UI_ALPHACLIP
					clip (c.a - 0.01);
                #endif

				return c;
			}

		    

			ENDCG
		}
	}
	FallBack "Diffuse"
}
