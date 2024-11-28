Shader "Custom/Hologram"
{
	    Properties
    {
        _RimColor("Rim Color", Color) = (0, 0.5, 0.5, 0.0)
        _RimPower("Rim Power", Range (0.5,8.0)) = 3.0
        _RimIntensity("Rim Intensity", Range(0.0, 10.0)) = 1.0
    }

    SubShader
    {
        Tags {"Queue" = "Transparent"}       

        Pass {
            ZWrite on
            ColorMask 0
            }

        CGPROGRAM
        #pragma surface surf Lambert alpha:fade
        struct Input
        {
            float3 viewDir;
        };

        fixed4 _RimColor;
        float _RimPower;
        float _RimIntensity; // Declare the rim intensity variable

        void surf (Input IN, inout SurfaceOutput o)
        {   
            half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
            o.Emission = _RimColor.rgb * pow(rim, _RimPower) * 50 * _RimIntensity;
            o.Alpha = pow(rim, _RimPower);      
        }
        ENDCG
    }
    FallBack "Diffuse"
}
