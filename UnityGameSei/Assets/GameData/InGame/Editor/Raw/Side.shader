

/** @brief ƒCƒ“ƒQ[ƒ€B
*/


Shader "InGame/Side"
{
	Properties
	{
		_Color		("_Color",Color)	= (1,1,1,1)
		inv_x		("inv_x",Float)		= 0.0
		inv_y		("inv_y",Float)		= 0.0
	}
	SubShader
	{
		Tags
		{
			"RenderType"	= "Transparent"
			"Queue"			= "Transparent"
		}
		Pass
		{
			Cull Off
			ZTest Always
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			/** appdata
			*/
			struct appdata
			{
				float4 vertex		: POSITION;
				float2 uv			: TEXCOORD0;
				float4 color		: COLOR0;
			};

			/** v2f
			*/
			struct v2f
			{
				float4 vertex		: SV_POSITION;
				float2 uv			: TEXCOORD0;
				float4 color		: COLOR0;
			};

			/** _Color
			*/
			float4 _Color;
		
			/** inv
			*/
			float inv_x;
			float inv_y;
		
			/** vert
			*/
			v2f vert(appdata a_appdata)
			{
				v2f t_ret;
				{
					t_ret.vertex = UnityObjectToClipPos(a_appdata.vertex);
					t_ret.uv = a_appdata.uv;
					t_ret.color = a_appdata.color;
				}
				return t_ret;
			}
			
			/** frag
			*/
			fixed4 frag(v2f a_v2f) : SV_Target
			{
				float4 t_color = _Color * a_v2f.color;

				float t_x = a_v2f.uv.x;
				if(inv_x > 0.0f){
					t_x = 1.0f - t_x;
				}

				float t_y = a_v2f.uv.y;
				if(inv_y > 0.0f){
					t_y = 1.0f - t_y;
				}

				float t_power = saturate(0.4f - pow((t_x + 0.2f) * (t_y + 0.2f),0.8f));
				t_color.a *= t_power;

				return t_color;
			}

			ENDCG
		}
	}
}

