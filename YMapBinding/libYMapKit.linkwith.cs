using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libYMapKit.a",
	LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, 
	Frameworks = "UIKit SystemConfiguration CoreGraphics CoreLocation Foundation OpenGLES QuartzCore", LinkerFlags = "-lz -lxml2.2")]
