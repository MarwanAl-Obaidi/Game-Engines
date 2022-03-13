#ifndef CUSTOM_LIGHTING_INCLUDED
#define CUSTOM_LIGHTING_INCLUDED

void MainLight_float(float3 WorldPos, out float3 Direction, out float3 Color, out float DistanceAtten, out float ShadowAtten)
{
	#if SHADERGRAPH_PREVIEW
		Direction = float3(-0.5, 0.5, 0);
		Color = float3(1, 0.95, 0.8);
		DistanceAtten = 1;
		ShadowAtten = 1;
	#else
		#if SHADOWS_SCREEN
			float4 clipPos = TransformWorldToHClip(WorldPos);
			float4 shadowCoord = ComputeScreenPos(clipPos);
		#else
			float4 shadowCoord = TransformWorldToShadowCoord(WorldPos);
		#endif
		Light mainLight = GetMainLight(shadowCoord);
		Direction = mainLight.direction;
		Color = mainLight.color;
		DistanceAtten = mainLight.distanceAttenuation;
		ShadowAtten = mainLight.shadowAttenuation;
	#endif
}
#endif