; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [238 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 72
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 103
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 96
	i32 101534019, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 86
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 86
	i32 146013796, ; 5: Mapsui.UI.Forms.dll => 0x8b3fe64 => 15
	i32 149764678, ; 6: Svg.Skia.dll => 0x8ed3a46 => 29
	i32 165246403, ; 7: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 53
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 87
	i32 209399409, ; 9: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 51
	i32 212497893, ; 10: Xamarin.Forms.Maps.Android => 0xcaa75e5 => 97
	i32 230216969, ; 11: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 67
	i32 232815796, ; 12: System.Web.Services => 0xde07cb4 => 114
	i32 261689757, ; 13: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 56
	i32 278686392, ; 14: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 71
	i32 280482487, ; 15: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 65
	i32 318968648, ; 16: Xamarin.AndroidX.Activity.dll => 0x13031348 => 43
	i32 319314094, ; 17: Xamarin.Forms.Maps => 0x130858ae => 98
	i32 321597661, ; 18: System.Numerics => 0x132b30dd => 34
	i32 342366114, ; 19: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 69
	i32 385762202, ; 20: System.Memory.dll => 0x16fe439a => 33
	i32 441335492, ; 21: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 55
	i32 442521989, ; 22: Xamarin.Essentials => 0x1a605985 => 95
	i32 450948140, ; 23: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 64
	i32 465658307, ; 24: ExCSS => 0x1bc161c3 => 6
	i32 465846621, ; 25: mscorlib => 0x1bc4415d => 18
	i32 469710990, ; 26: System.dll => 0x1bff388e => 32
	i32 469965489, ; 27: Svg.Model => 0x1c031ab1 => 28
	i32 476646585, ; 28: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 65
	i32 486930444, ; 29: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 76
	i32 525008092, ; 30: SkiaSharp.dll => 0x1f4afcdc => 23
	i32 526420162, ; 31: System.Transactions.dll => 0x1f6088c2 => 109
	i32 548916678, ; 32: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 16
	i32 605376203, ; 33: System.IO.Compression.FileSystem => 0x24154ecb => 112
	i32 627609679, ; 34: Xamarin.AndroidX.CustomView => 0x2568904f => 60
	i32 662205335, ; 35: System.Text.Encodings.Web.dll => 0x27787397 => 38
	i32 663517072, ; 36: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 92
	i32 666292255, ; 37: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 48
	i32 680049820, ; 38: Mapsui.Rendering.Skia.dll => 0x2888bc9c => 13
	i32 690569205, ; 39: System.Xml.Linq.dll => 0x29293ff5 => 41
	i32 751771013, ; 40: Geo => 0x2ccf1d85 => 8
	i32 775507847, ; 41: System.IO.Compression => 0x2e394f87 => 111
	i32 778756650, ; 42: SkiaSharp.HarfBuzz.dll => 0x2e6ae22a => 24
	i32 809851609, ; 43: System.Drawing.Common.dll => 0x30455ad9 => 2
	i32 843511501, ; 44: Xamarin.AndroidX.Print => 0x3246f6cd => 83
	i32 899130691, ; 45: NetTopologySuite.dll => 0x3597a543 => 19
	i32 928116545, ; 46: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 103
	i32 967690846, ; 47: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 69
	i32 974778368, ; 48: FormsViewGroup.dll => 0x3a19f000 => 7
	i32 1012816738, ; 49: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 85
	i32 1035644815, ; 50: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 47
	i32 1042160112, ; 51: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 100
	i32 1052210849, ; 52: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 73
	i32 1098259244, ; 53: System => 0x41761b2c => 32
	i32 1175144683, ; 54: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 90
	i32 1178241025, ; 55: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 80
	i32 1204270330, ; 56: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 48
	i32 1267360935, ; 57: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 91
	i32 1293217323, ; 58: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 62
	i32 1313028017, ; 59: Topten.RichTextKit => 0x4e4337b1 => 42
	i32 1350187636, ; 60: Mapsui.UI.Forms => 0x507a3a74 => 15
	i32 1365406463, ; 61: System.ServiceModel.Internals.dll => 0x516272ff => 115
	i32 1376866003, ; 62: Xamarin.AndroidX.SavedState => 0x52114ed3 => 85
	i32 1388087747, ; 63: Mapsui.dll => 0x52bc89c3 => 11
	i32 1395857551, ; 64: Xamarin.AndroidX.Media.dll => 0x5333188f => 77
	i32 1406073936, ; 65: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 57
	i32 1411638395, ; 66: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 36
	i32 1422967952, ; 67: Mapsui.Tiling.dll => 0x54d0c490 => 14
	i32 1443938015, ; 68: NetTopologySuite => 0x5610bedf => 19
	i32 1460219004, ; 69: Xamarin.Forms.Xaml => 0x57092c7c => 101
	i32 1462112819, ; 70: System.IO.Compression.dll => 0x57261233 => 111
	i32 1469204771, ; 71: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 46
	i32 1530663695, ; 72: Xamarin.Forms.Maps.dll => 0x5b3c130f => 98
	i32 1582372066, ; 73: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 61
	i32 1592978981, ; 74: System.Runtime.Serialization.dll => 0x5ef2ee25 => 4
	i32 1600541741, ; 75: ShimSkiaSharp => 0x5f66542d => 22
	i32 1622152042, ; 76: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 75
	i32 1624863272, ; 77: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 94
	i32 1636350590, ; 78: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 59
	i32 1639515021, ; 79: System.Net.Http.dll => 0x61b9038d => 3
	i32 1657153582, ; 80: System.Runtime => 0x62c6282e => 37
	i32 1658241508, ; 81: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 88
	i32 1658251792, ; 82: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 102
	i32 1670060433, ; 83: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 56
	i32 1672364457, ; 84: NetTopologySuite.IO.GeoJSON4STJ.dll => 0x63ae41a9 => 21
	i32 1722051300, ; 85: SkiaSharp.Views.Forms => 0x66a46ae4 => 26
	i32 1729485958, ; 86: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 52
	i32 1766324549, ; 87: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 87
	i32 1776026572, ; 88: System.Core.dll => 0x69dc03cc => 31
	i32 1788241197, ; 89: Xamarin.AndroidX.Fragment => 0x6a96652d => 64
	i32 1796167890, ; 90: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 16
	i32 1808609942, ; 91: Xamarin.AndroidX.Loader => 0x6bcd3296 => 75
	i32 1813201214, ; 92: Xamarin.Google.Android.Material => 0x6c13413e => 102
	i32 1818569960, ; 93: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 81
	i32 1839733746, ; 94: Mapsui.Nts.dll => 0x6da81bf2 => 12
	i32 1867746548, ; 95: Xamarin.Essentials.dll => 0x6f538cf4 => 95
	i32 1878053835, ; 96: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 101
	i32 1881862856, ; 97: Xamarin.Forms.Maps.Android.dll => 0x702af2c8 => 97
	i32 1885316902, ; 98: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 49
	i32 1908813208, ; 99: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 105
	i32 1919157823, ; 100: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 78
	i32 2006555782, ; 101: Geo.Android => 0x77999c86 => 0
	i32 2011961780, ; 102: System.Buffers.dll => 0x77ec19b4 => 30
	i32 2019465201, ; 103: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 73
	i32 2055257422, ; 104: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 70
	i32 2079903147, ; 105: System.Runtime.dll => 0x7bf8cdab => 37
	i32 2090596640, ; 106: System.Numerics.Vectors => 0x7c9bf920 => 35
	i32 2097448633, ; 107: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 66
	i32 2126786730, ; 108: Xamarin.Forms.Platform.Android => 0x7ec430aa => 99
	i32 2129483829, ; 109: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 104
	i32 2201231467, ; 110: System.Net.Http => 0x8334206b => 3
	i32 2217644978, ; 111: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 90
	i32 2244775296, ; 112: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 76
	i32 2256548716, ; 113: Xamarin.AndroidX.MultiDex => 0x8680336c => 78
	i32 2261435625, ; 114: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 68
	i32 2279755925, ; 115: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 84
	i32 2315684594, ; 116: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 44
	i32 2327893114, ; 117: ExCSS.dll => 0x8ac0d47a => 6
	i32 2409053734, ; 118: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 82
	i32 2465532216, ; 119: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 55
	i32 2471841756, ; 120: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 121: Java.Interop.dll => 0x93918882 => 10
	i32 2501346920, ; 122: System.Data.DataSetExtensions => 0x95178668 => 110
	i32 2505896520, ; 123: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 72
	i32 2523023297, ; 124: Svg.Custom.dll => 0x966247c1 => 27
	i32 2570120770, ; 125: System.Text.Encodings.Web => 0x9930ee42 => 38
	i32 2577414832, ; 126: Mapsui.Nts => 0x99a03ab0 => 12
	i32 2581819634, ; 127: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 91
	i32 2602257211, ; 128: Svg.Model.dll => 0x9b1b4b3b => 28
	i32 2609324236, ; 129: Svg.Custom => 0x9b8720cc => 27
	i32 2620871830, ; 130: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 59
	i32 2624644809, ; 131: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 63
	i32 2633051222, ; 132: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 71
	i32 2701096212, ; 133: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 88
	i32 2732626843, ; 134: Xamarin.AndroidX.Activity => 0xa2e0939b => 43
	i32 2737747696, ; 135: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 46
	i32 2756874198, ; 136: NetTopologySuite.IO.GeoJSON4STJ => 0xa4528fd6 => 21
	i32 2765824710, ; 137: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 116
	i32 2766581644, ; 138: Xamarin.Forms.Core => 0xa4e6af8c => 96
	i32 2778768386, ; 139: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 93
	i32 2795602088, ; 140: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 25
	i32 2810250172, ; 141: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 57
	i32 2819470561, ; 142: System.Xml.dll => 0xa80db4e1 => 40
	i32 2847418871, ; 143: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 104
	i32 2853208004, ; 144: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 93
	i32 2855708567, ; 145: Xamarin.AndroidX.Transition => 0xaa36a797 => 89
	i32 2903344695, ; 146: System.ComponentModel.Composition => 0xad0d8637 => 113
	i32 2905242038, ; 147: mscorlib.dll => 0xad2a79b6 => 18
	i32 2912489636, ; 148: SkiaSharp.Views.Android => 0xad9910a4 => 25
	i32 2916838712, ; 149: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 94
	i32 2919462931, ; 150: System.Numerics.Vectors.dll => 0xae037813 => 35
	i32 2921128767, ; 151: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 45
	i32 2974793899, ; 152: SkiaSharp.Views.Forms.dll => 0xb14fc0ab => 26
	i32 2978675010, ; 153: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 62
	i32 3017076677, ; 154: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 106
	i32 3024354802, ; 155: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 67
	i32 3044182254, ; 156: FormsViewGroup => 0xb57288ee => 7
	i32 3057625584, ; 157: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 79
	i32 3058099980, ; 158: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 107
	i32 3111772706, ; 159: System.Runtime.Serialization => 0xb979e222 => 4
	i32 3124832203, ; 160: System.Threading.Tasks.Extensions => 0xba4127cb => 118
	i32 3134694676, ; 161: ShimSkiaSharp.dll => 0xbad7a514 => 22
	i32 3204380047, ; 162: System.Data.dll => 0xbefef58f => 108
	i32 3211777861, ; 163: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 61
	i32 3230466174, ; 164: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 105
	i32 3247949154, ; 165: Mono.Security => 0xc197c562 => 117
	i32 3258312781, ; 166: Xamarin.AndroidX.CardView => 0xc235e84d => 52
	i32 3265893370, ; 167: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 118
	i32 3267021929, ; 168: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 50
	i32 3278552754, ; 169: Mapsui => 0xc36abeb2 => 11
	i32 3317135071, ; 170: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 60
	i32 3317144872, ; 171: System.Data => 0xc5b79d28 => 108
	i32 3340387945, ; 172: SkiaSharp => 0xc71a4669 => 23
	i32 3340431453, ; 173: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 49
	i32 3346324047, ; 174: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 80
	i32 3353484488, ; 175: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 66
	i32 3358260929, ; 176: System.Text.Json => 0xc82afec1 => 39
	i32 3362522851, ; 177: Xamarin.AndroidX.Core => 0xc86c06e3 => 58
	i32 3366347497, ; 178: Java.Interop => 0xc8a662e9 => 10
	i32 3374999561, ; 179: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 84
	i32 3395150330, ; 180: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 36
	i32 3404865022, ; 181: System.ServiceModel.Internals => 0xcaf21dfe => 115
	i32 3429136800, ; 182: System.Xml => 0xcc6479a0 => 40
	i32 3430777524, ; 183: netstandard => 0xcc7d82b4 => 1
	i32 3441283291, ; 184: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 63
	i32 3459815001, ; 185: Mapsui.Rendering.Skia => 0xce389659 => 13
	i32 3476120550, ; 186: Mono.Android => 0xcf3163e6 => 17
	i32 3485117614, ; 187: System.Text.Json.dll => 0xcfbaacae => 39
	i32 3486566296, ; 188: System.Transactions => 0xcfd0c798 => 109
	i32 3493954962, ; 189: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 54
	i32 3501239056, ; 190: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 50
	i32 3509114376, ; 191: System.Xml.Linq => 0xd128d608 => 41
	i32 3536029504, ; 192: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 99
	i32 3567349600, ; 193: System.ComponentModel.Composition.dll => 0xd4a16f60 => 113
	i32 3618140916, ; 194: Xamarin.AndroidX.Preference => 0xd7a872f4 => 82
	i32 3627220390, ; 195: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 83
	i32 3632359727, ; 196: Xamarin.Forms.Platform => 0xd881692f => 100
	i32 3633644679, ; 197: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 45
	i32 3641597786, ; 198: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 70
	i32 3672681054, ; 199: Mono.Android.dll => 0xdae8aa5e => 17
	i32 3676310014, ; 200: System.Web.Services.dll => 0xdb2009fe => 114
	i32 3682565725, ; 201: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 51
	i32 3684561358, ; 202: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 54
	i32 3689375977, ; 203: System.Drawing.Common => 0xdbe768e9 => 2
	i32 3708150058, ; 204: Geo.dll => 0xdd05e12a => 8
	i32 3718780102, ; 205: Xamarin.AndroidX.Annotation => 0xdda814c6 => 44
	i32 3724971120, ; 206: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 79
	i32 3758932259, ; 207: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 68
	i32 3786282454, ; 208: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 53
	i32 3792835768, ; 209: HarfBuzzSharp => 0xe21214b8 => 9
	i32 3798102808, ; 210: BruTile => 0xe2627318 => 5
	i32 3822602673, ; 211: Xamarin.AndroidX.Media => 0xe3d849b1 => 77
	i32 3829621856, ; 212: System.Numerics.dll => 0xe4436460 => 34
	i32 3885922214, ; 213: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 89
	i32 3896760992, ; 214: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 58
	i32 3920810846, ; 215: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 112
	i32 3921031405, ; 216: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 92
	i32 3931092270, ; 217: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 81
	i32 3934069706, ; 218: Topten.RichTextKit.dll => 0xea7d23ca => 42
	i32 3945713374, ; 219: System.Data.DataSetExtensions.dll => 0xeb2ecede => 110
	i32 3952289091, ; 220: NetTopologySuite.Features.dll => 0xeb932543 => 20
	i32 3953583589, ; 221: Svg.Skia => 0xeba6e5e5 => 29
	i32 3953953790, ; 222: System.Text.Encoding.CodePages => 0xebac8bfe => 116
	i32 3955647286, ; 223: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 47
	i32 3970018735, ; 224: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 107
	i32 4003906742, ; 225: HarfBuzzSharp.dll => 0xeea6c4b6 => 9
	i32 4013003792, ; 226: BruTile.dll => 0xef319410 => 5
	i32 4022681963, ; 227: Mapsui.Tiling => 0xefc5416b => 14
	i32 4025784931, ; 228: System.Memory => 0xeff49a63 => 33
	i32 4066802364, ; 229: SkiaSharp.HarfBuzz => 0xf2667abc => 24
	i32 4105002889, ; 230: Mono.Security.dll => 0xf4ad5f89 => 117
	i32 4144557198, ; 231: NetTopologySuite.Features => 0xf708ec8e => 20
	i32 4151237749, ; 232: System.Core => 0xf76edc75 => 31
	i32 4165167394, ; 233: Geo.Android.dll => 0xf8436922 => 0
	i32 4182413190, ; 234: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 74
	i32 4260525087, ; 235: System.Buffers => 0xfdf2741f => 30
	i32 4278134329, ; 236: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 106
	i32 4292120959 ; 237: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 74
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [238 x i32] [
	i32 72, i32 103, i32 96, i32 86, i32 86, i32 15, i32 29, i32 53, ; 0..7
	i32 87, i32 51, i32 97, i32 67, i32 114, i32 56, i32 71, i32 65, ; 8..15
	i32 43, i32 98, i32 34, i32 69, i32 33, i32 55, i32 95, i32 64, ; 16..23
	i32 6, i32 18, i32 32, i32 28, i32 65, i32 76, i32 23, i32 109, ; 24..31
	i32 16, i32 112, i32 60, i32 38, i32 92, i32 48, i32 13, i32 41, ; 32..39
	i32 8, i32 111, i32 24, i32 2, i32 83, i32 19, i32 103, i32 69, ; 40..47
	i32 7, i32 85, i32 47, i32 100, i32 73, i32 32, i32 90, i32 80, ; 48..55
	i32 48, i32 91, i32 62, i32 42, i32 15, i32 115, i32 85, i32 11, ; 56..63
	i32 77, i32 57, i32 36, i32 14, i32 19, i32 101, i32 111, i32 46, ; 64..71
	i32 98, i32 61, i32 4, i32 22, i32 75, i32 94, i32 59, i32 3, ; 72..79
	i32 37, i32 88, i32 102, i32 56, i32 21, i32 26, i32 52, i32 87, ; 80..87
	i32 31, i32 64, i32 16, i32 75, i32 102, i32 81, i32 12, i32 95, ; 88..95
	i32 101, i32 97, i32 49, i32 105, i32 78, i32 0, i32 30, i32 73, ; 96..103
	i32 70, i32 37, i32 35, i32 66, i32 99, i32 104, i32 3, i32 90, ; 104..111
	i32 76, i32 78, i32 68, i32 84, i32 44, i32 6, i32 82, i32 55, ; 112..119
	i32 1, i32 10, i32 110, i32 72, i32 27, i32 38, i32 12, i32 91, ; 120..127
	i32 28, i32 27, i32 59, i32 63, i32 71, i32 88, i32 43, i32 46, ; 128..135
	i32 21, i32 116, i32 96, i32 93, i32 25, i32 57, i32 40, i32 104, ; 136..143
	i32 93, i32 89, i32 113, i32 18, i32 25, i32 94, i32 35, i32 45, ; 144..151
	i32 26, i32 62, i32 106, i32 67, i32 7, i32 79, i32 107, i32 4, ; 152..159
	i32 118, i32 22, i32 108, i32 61, i32 105, i32 117, i32 52, i32 118, ; 160..167
	i32 50, i32 11, i32 60, i32 108, i32 23, i32 49, i32 80, i32 66, ; 168..175
	i32 39, i32 58, i32 10, i32 84, i32 36, i32 115, i32 40, i32 1, ; 176..183
	i32 63, i32 13, i32 17, i32 39, i32 109, i32 54, i32 50, i32 41, ; 184..191
	i32 99, i32 113, i32 82, i32 83, i32 100, i32 45, i32 70, i32 17, ; 192..199
	i32 114, i32 51, i32 54, i32 2, i32 8, i32 44, i32 79, i32 68, ; 200..207
	i32 53, i32 9, i32 5, i32 77, i32 34, i32 89, i32 58, i32 112, ; 208..215
	i32 92, i32 81, i32 42, i32 110, i32 20, i32 29, i32 116, i32 47, ; 216..223
	i32 107, i32 9, i32 5, i32 14, i32 33, i32 24, i32 117, i32 20, ; 224..231
	i32 31, i32 0, i32 74, i32 30, i32 106, i32 74 ; 232..237
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
