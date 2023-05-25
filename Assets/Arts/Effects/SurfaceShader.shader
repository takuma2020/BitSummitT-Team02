Shader "My/URPLit"
{
	Properties
	{

		 _OutlineCol("OutlineCol", Color) = (1,0,0,1)
		 _OutlineFactor("OutlineFactor", Range(0,10)) = 0.1
		_OutLineIntensity("OutLineIntensity", Range(0,10)) = 0.1

		 [MainTexture] _BaseMap("Albedo", 2D) = "white" {}
		[MainColor] _BaseColor("Color", Color) = (1,1,1,1)

		[HideInInspector] _SrcBlend("__src", Float) = 1.0
		[HideInInspector] _DstBlend("__dst", Float) = 0.0
		[HideInInspector] _ZWrite("__zw", Float) = 1.0

		[ToggleUI] _ReceiveShadows("Receive Shadows", Float) = 1.0

	}

		SubShader
		{
		Tags{"RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" "UniversalMaterialType" = "Lit" "IgnoreProjector" = "True" "ShaderModel" = "4.5"}
			LOD 300

			Pass
			{
				Name "ForwardLit"
				Tags{"LightMode" = "UniversalForward"}
				
				Blend[_SrcBlend][_DstBlend]
				ZWrite[_ZWrite]
				Cull[_Cull]

				Stencil
				{
					Ref 250
					Comp Always
					Pass Replace
				}

				HLSLPROGRAM
				#pragma exclude_renderers gles gles3 glcore
				#pragma target 4.5

			// Universal Pipeline keywords
			#pragma multi_compile _ _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
			#pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
			#pragma multi_compile _ LIGHTMAP_SHADOW_MIXING
			#pragma multi_compile _ SHADOWS_SHADOWMASK
			#pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BLENDING
			#pragma multi_compile_fragment _ _REFLECTION_PROBE_BOX_PROJECTION
			#pragma multi_compile_fragment _ _SHADOWS_SOFT
			#pragma multi_compile_fragment _ _SCREEN_SPACE_OCCLUSION
			#pragma multi_compile_fragment _ _DBUFFER_MRT1 _DBUFFER_MRT2 _DBUFFER_MRT3
			#pragma multi_compile_fragment _ _LIGHT_LAYERS
			#pragma multi_compile_fragment _ _LIGHT_COOKIES
			#pragma multi_compile _ _CLUSTERED_RENDERING

			#pragma vertex LitPassVertex
			#pragma fragment LitPassFragment

			#include "Packages/com.unity.render-pipelines.universal/Shaders/LitInput.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/Shaders/LitForwardPass.hlsl"

			ENDHLSL
		}

  Pass
	 {
		Cull Front
		Name "Outline"
		Stencil
		{
			Ref 250
			Comp NotEqual
		}

		Tags
		{
			"LightMode" = "SRPDefaultUnlit"
		}

			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

			float4 _OutlineCol;
			float _OutlineFactor;
			float _OutLineIntensity;

			   struct appdata
				{
					float4 vertex : POSITION;
					float3 normal : NORMAL;
				};

				struct v2f
				{
					float4 vertex : SV_POSITION;
				};


				v2f vert(appdata v)
				{
					v2f o;

				   v.vertex.xyz *= _OutlineFactor;

					  o.vertex = TransformObjectToHClip(v.vertex);
					  return o;
				  }

				half4 frag(v2f i) : SV_Target
				{


					//_OutlineCol *= dotProduct;
					_OutlineCol *= _OutLineIntensity;
					  return _OutlineCol;
				  }

			  ENDHLSL
		}
		}

			FallBack "Hidden/Universal Render Pipeline/FallbackError"
}