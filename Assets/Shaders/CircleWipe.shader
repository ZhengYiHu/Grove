Shader "Unlit/CircleWipe" {
 Properties
 {
     [Header(TOP)]
     [NoScaleOffset]_MainTex ("Texture", 2D) = "w$$anonymous$$te" {}
     _TopTint("Tint", Color) = (1,1,1,1)
 
     [Space][Header(BOTTOM)]
     [NoScaleOffset]_BottomTex("Texture", 2D) = "w$$anonymous$$te" {}
     [HDR] _BottomTint("Tint", Color) = (1,1,1,1)
 
     [Space][Header(DECAL)]
     [NoScaleOffset]_DecalTex("Texture", 2D) = "w$$anonymous$$te" {}
     [HDR] _DecalTint("Tint", Color) = (1,1,1,0)
     _DecalScale("Scale", Float) = 1
     
     [Space][Header(BLEND)]
     _Radius("Radius", Float) = 0.2
     _RadiusThickness("Radius Thickness", Float) = 0.1
     _BlendColour("Color", Color) = (1,1,1,1)
     
     [Space][Header(RATIO)]
     _Horizontal("Horizontal", Float) = 1
     _Vertical("Vertical", Float) = 1
 
     [Space][Header(CENTER)]
     _CenterX("X", Range(0,1)) = 0.5
     _CenterY("Y", Range(0,1)) = 0.5
 }
 SubShader
 {
     Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
     Blend SrcAlpha OneMinusSrcAlpha
 
     Pass
     {
         CGPROGRAM
         #pragma vertex vert
         #pragma fragment frag
         #include "UnityCG.cginc"
 
         struct appdata
         {
             half4 vertex : POSITION;
             half2 uv : TEXCOORD0;
         };
 
         struct v2f
         {
             half2 uv : TEXCOORD0;
             half4 vertex : SV_POSITION;
         };
 
         sampler2D _MainTex, _BottomTex, _DecalTex;
         half4 _TopTint : COLOR, _BottomTint : COLOR, _BlendColour : COLOR, _DecalTint : COLOR;
         half _CenterX, _CenterY, _RadiusThickness, _Radius, _Horizontal, _Vertical, _DecalScale;
 
         v2f vert ( in appdata v )
         {
             v2f o;
             o.vertex = UnityObjectToClipPos( v.vertex );
             o.uv = v.uv;
             return o;
         }
 
         half arch ( half t ) { return t * ( 1.0 - t ); }
 
         fixed4 frag ( in v2f i ) : SV_Target
         {
             half2 center = fixed2( _CenterX , _CenterY );
             half2 pos = i.uv.xy;
             half2 dir = (pos-center) / fixed2(_Horizontal,_Vertical);
             half t = smoothstep( _Radius - _RadiusThickness , _Radius , length(dir) );
 
             fixed4 ctop = _TopTint * tex2D( _MainTex , i.uv );
             fixed4 cbottom = _BottomTint * tex2D( _BottomTex , i.uv );
             half2 uvdecal = (i.uv-0.5) /_DecalScale/fixed2(_Horizontal,_Vertical) +0.5 -(center-0.5)/_DecalScale/fixed2(_Horizontal,_Vertical);
             fixed4 cdecal = _DecalTint * tex2D( _DecalTex , uvdecal );
             
             fixed4 ctopbottom = lerp( cbottom , ctop , t );
             fixed4 ctopbottomblend = lerp( ctopbottom , _BlendColour , arch(t) );
             fixed4 ctopbottomblenddecal = lerp( ctopbottomblend , cdecal , cdecal.a );
 
             return ctopbottomblenddecal;
         }
         ENDCG
     }
 }
 }