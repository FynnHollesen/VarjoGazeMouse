using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Varjo.NET
{
    public enum VarjoError : long
    {
        InvalidSession = 1,
        OutOfMemory = 2,
        InvalidVersion = 3,
        GraphicsNotInitialized = 4,
        FrameNotStarted = 5,
        FrameAlreadyStarted = 6,
        ViewIndexOutOfBounds = 7,
        InvalidPoseType = 8,
        NullPointer = 9,
        MixingTextures = 10,
        NaN = 11,
        NoHMDConnected = 12,
        ValidationFailure = 13,
        IndexOutOfBounds = 14,
        AlreadyLocked = 15,
        NotLocked = 16,
        InvalidSize = 17,
        InvalidParameter = 104,
        UnsupportedParameter = 105,

        /// Gaze errors (100 - 199)
        GazeNotInitialized = 100,
        GazeNotConnected = 101,
        GazeAlreadyInitialized = 102,
        GazeNotAllowed = 103,
        GazeInvalidParameter = 104,      // Deprecated, use InvalidParameter instead
        GazeUnsupportedParameter = 105,  // Deprecated, use UnsupportedParameter instead

        // Graphics errors (200 - 299)
        D3D11DeviceCreationFailed = 200,
        GetD3D11_1DeviceFailed = 201,
        AcquireD3D11DeviceHandleFailed = 202,
        GLBackBufferAlreadyCreated = 203,
        GLExtensionNotFound = 204,
        GLCreateTextureFailed = 205,
        GLAcquireD3D11TextureHandleFailed = 206,
        GLLockTextureFailed = 207,
        GLCopyTextureFailed = 208,
        OpenSharedTextureFailed = 209,
        TextureMutexQueryFailed = 210,
        TextureMutexAcquireFailed = 211,
        TextureMutexReleaseFailed = 212,
        D3D11AlreadyInitialized = 213,
        D3D11ShutDownFailed = 214,
        GLAlreadyInitialized = 215,
        GLShutDownFailed = 216,
        UnsupportedTextureFormat = 217,
        SwapChainConfigInvalidWidth = 219,
        SwapChainConfigInvalidHeight = 220,
        SwapChainConfigInvalidTextureCount = 221,
        GraphicsShutDownFailed = 222,
        TextureIsNull = 223,
        InvalidFrameNumber = 224,
        InvalidRenderAPI = 225,
        InvalidMatrix = 226,
        UnsupportedDepthFormat = 227,
        InvalidClipDistances = 229,
        SwapChainInvalidTextureIndex = 230,
        D3D11CreateTextureFailed = 231,
        InvalidSwapChainRect = 232,
        ViewDepthExtensionValidationFailure = 233,
        D3D11OnD12DeviceCreationFailed = 234,
        D3D12CreateTextureFailed = 235,
        InvalidSwapChain = 236,
        WrongSwapChainTextureFormat = 237,
        InvalidViewExtension = 238,
        InvalidViewport = 239,
        GraphicsError = 240,
        InvalidTextureSizeType = 241,
        SwapChainTextureIsNotReleased = 242,
        GazeInvalid = 243,

        // Compositor errors (300 - 399)
        ConnectToProgramManagerFailed = 300,
        RequestSwapChainFormatFailed = 301,
        OpenSharedEventFailed = 302,
        CreateIPCFailed = 303,
        InitializeCompositorLinkFailed = 304,
        RequestViewInfoFailed = 305,
        NoCompositorLink = 306,
        RequestCreateSwapChainFailed = 307,
        RequestMirrorConfigFailed = 308,

        // Mixed reality errors (700 - 799)
        RequestFailed = 700,
        OperationFailed = 701,
        NotAvailable = 702,
        CapabilityNotAvailable = 703,
        CameraAlreadyLocked = 704,
        CameraNotLocked = 705,
        CameraInvalidPropertyType = 706,
        CameraInvalidPropertyValue = 707,
        CameraInvalidPropertyMode = 708,
        ChromaKeyAlreadyLocked = 709,
        ChromaKeyNotLocked = 710,
        ChromaKeyInvalidType = 711,
        ChromaKeyEstimatorAlreadyRunning = 712,
        ChromaKeyEstimatorNotRunning = 713,
        EnvironmentCubemapNotLocked = 714,
        EnvironmentCubemapInvalidMode = 715,

        // Data stream errors (800 - 899)
        DataStreamInvalidCallback = 800,
        DataStreamInvalidId = 801,
        DataStreamAlreadyInUse = 802,
        DataStreamNotInUse = 803,
        DataStreamBufferInvalidId = 804,
        DataStreamBufferAlreadyLocked = 805,
        DataStreamBufferNotLocked = 806,
        DataStreamFrameExpired = 807,
        DataStreamDataNotAvailable = 808,

        // World errors (900 - 999)
        WorldObjectMarkersNotInitialized = 900,
        WorldComponentDoesNotExist = 901,
        WorldMarkerExpirationDurationIsNegative = 902,

        // Foveation and variable rate shading errors (1000 - 1099)
        InvalidFoveationMode = 1000,
        UnableToInitializeVariableRateShading = 1001,
        InvalidVariableRateShadingRadius = 1002,

        // Special error codes
        NoError = 0,
        Unknown = -1,
    }

    public enum VarjoGazeStatus : long
    {
        Invalid = 0, // Data is not available, user is not wearing the device or eyes can not be found.
        Adjust = 1, // User is wearing the device but gaze tracking is in middle of adjustment.
        Valid = 2, // Data is valid.
    }

    public enum VarjoGazeEyeStatus : long
    {
        Invalid = 0, // Eye is not tracked. (e.g. not visible or is shut).
        Visible = 1, // Eye is visible but not reliably tracked (e.g. saccade or blink).
        Compensated = 2, // Eye is tracked but quality compromised (e.g. headset has moved after calibration).
        Tracked = 3, // Eye is tracked.
    }

    public enum VarjoGazeEyeCalibrationQuality : int
    {
        Invalid = 0, // Gaze calibration was not performed or failed.
        Low = 1, // Quality of performed gaze calibration assessed as low.
        Medium = 2, // Quality of performed gaze calibration assessed as medium.
        High = 3, // Quality of performed gaze calibration assessed as high.
    }

    public enum VarjoRotationReset : long
    {
        None = 0, // Rotation is not reset.
        Yaw = 1, // Yaw rotation (around up Y axis) is reset.
        All = 7, // All rotation axes are reset.
    }

    public enum VarjoPropertyKey : long
    {
        Invalid = 0x0, // Invalid property key.
        UserPresence = 0x2000, // boolean. Is user wearing the HMD.
        GazeCalibrating = 0xA000, // boolean. Is system currently calibrating the HMD gaze tracker.
        GazeCalibrated = 0xA001, // boolean. Is the HMD gaze tracker calibrated.
        GazeCalibrationQuality = 0xA002, // float [0.0-1.0]. Quality of the gaze calibration.
        GazeAllowed = 0xA003, // boolean. Is the HMD gaze tracker allowed.
        GazeEyeCalibrationQuality_Left = 0xA004, // float [0.0-1.0]. Quality assessment of the left eye gaze calibration.
        GazeEyeCalibrationQuality_Right = 0xA005, // float [0.0-1.0]. Quality assessment of the right eye gaze calibration.
        GazeIPDEstimate = 0xA010, // float. User interpupillary distance estimate in millimeters.
        HMDConnected = 0xE001, // boolean. Is HMD connected.
        HMDProductName = 0xE002, // string. Product name.
        HMDSerialNumber = 0xE003, // string. Product serial number.
        IPDPosition = 0xE010, // float. HMD interpupillary distance position in millimeters.
        IPDAdjustmentMode = 0xE011, // string. Current interpupillary distance adjustment mode.
        MRAvailable = 0xD000, // boolean. Is Mixed Reality capable hardware present.
    }

    public enum VarjoPoseType : long
    {
        LeftEye = 0x1, // Pose for the left eye.
        Center = 0x2, // Pose for the head (in the middle of the eyes).
        RightEye = 0x3, // Pose for the right eye.
    }

    public enum VarjoDisplayType : long
    {
        Focus = 0x1, // Focus display.
        Context = 0x2, // Context display.
    }

    public enum VarjoEye : long
    {
        Left = 0x1, // Left eye.
        Right = 0x2, // Right eye.
    }

    public enum VarjoWindingOrder : long
    {
        Clockwise = 0x1, // Clockwise triangle winding.
        CounterClockwise = 0x2, // Counter-clockwise triangle winding.
    }

    public enum VarjoTextureFormat : long
    {
        INVALID = 0, // Invalid format
        R8G8B8A8_SRGB = 1, // sRgb 8-bit RGBA format
        B8G8R8A8_SRGB = 2, // sRgb 8-bit BGRA format
        DepthTextureFormat_D32_FLOAT = 3, // 32-bit floating point depth format
        MaskTextureFormat_A8_UNORM = 4, // 8-bit alpha mask
        YUV422 = 5, // YUV 4:2:2 semi-planar, 8bit Y plane, 8+8bit interleaved UV plane
        RGBA16_FLOAT = 6, // RGBA 16 bit floating point
        DepthTextureFormat_D24_UNORM_S8_UINT = 7, // 24-bit UNORM depth and 8-bit UINT stencil format
        DepthTextureFormat_D32_FLOAT_S8_UINT = 8, // 32-bit FLOAT depth abd 8-bit UINT stencil format
        R8G8B8A8_UNORM = 9, // Rgb 8-bit RGBA format
        R32_FLOAT = 10, // Single channel 32-bit float format
        R32_UINT = 11, // Single channel 32-bit uint format
        VelocityTextureFormat_R8G8B8A8_UINT = 12, // Two 16-bit integers packed into 4 bytes
        NV12 = 13, // YUV 4:2:0 semi-planar in NV12 format (8bit Y plane, 8+8bit interleaved UV plane in half resolution)
        B8G8R8A8_UNORM = 14, // Rgb 8-bit BGRA format
        Y8_UNORM = 15, // 8-bit Y plane only
    }
    public enum VarjoRenderAPI : long
    {
        D3D11 = 0x1, // Direct3D11 rendering API
        GL = 0x2, // OpenGL rendering API
        D3D12 = 0x3, // Direct3D12 rendering API
        Vulkan = 0x4, // Vulkan rendering API
    }

    public enum VarjoEulerOrder : long
    {
        XYZ = 0,
        ZYX = 1,
        XZY = 2,
        YZX = 3,
        YXZ = 4,
        ZXY = 5,
    }

    public enum VarjoRotationDirection : long
    {
        Clockwise = -1,
        CounterClockwise = 1,
    }

    public enum VarjoHandedness : long
    {
        RightHanded = 1,
        LeftHanded = -1,
    }

    public enum VarjoClipRange : long
    {
        ZeroToOne = 0,
        MinusOneToOne = 1,
    }

    public static class VarjoIPDParametersKey
    {
        public const string AdjustmentMode = "AdjustmentMode"; // Interpupillary distance adjustment mode.
        public const string RequestedPositionInMM = "RequestedPositionInMM"; // Requested interpupillary distance position in millimeters in manual adjustment mode.
    }

    public static class VarjoIPDParametersValue
    {
        public const string AdjustmentModeManual = "Manual"; // Interpupillary distance is adjusted manually.
        public const string AdjustmentModeAutomatic = "Automatic"; // Interpupillary distance is adjusted automatically.
    }

    public static class VarjoGazeParametersKey
    {
        public const string OutputFilterType = "OutputFilterType"; // Gaze output filter type.
        public const string OutputFrequency = "OutputFrequency"; // Gaze output update frequency.
    }

    public static class VarjoGazeParametersValue
    {
        public const string OutputFilterStandard = "Standard"; // Standard smoothing output filter.
        public const string OutputFilterNone = "None"; // Output filter disabled.
        public const string OutputFrequency100Hz = "OutputFrequency100Hz"; // 100Hz output frequency. Default mode.
        public const string OutputFrequency200Hz = "OutputFrequency200Hz"; // 200Hz output frequency.
        public const string OutputFrequencyMaximumSupported = "OutputFrequencyMaximumSupported"; // Maximum output frequency supported by connected HMD.
    }

    public static class VarjoGazeCalibrationParametersKey
    {
        public const string CalibrationType = "GazeCalibrationType"; // Gaze calibration type.
        public const string HeadsetAlignmentGuidanceMode = "HeadsetAlignmentGuidanceMode"; // Controls behavior of headset alignment guidance user interface during calibration process.
    }

    public static class VarjoGazeCalibrationParametersValue
    {
        public const string CalibrationFast = "Fast"; // Fast (5-dot) gaze calibration.
        public const string CalibrationOneDot = "OneDot"; // One dot gaze calibration
        public const string CalibrationLegacy = "Legacy"; // Deprecated. Don't use in new code. This will just trigger a fallback to 'Fast' calibration.
        public const string WaitForUserInputToContinue = "WaitForUserInputToContinue"; // UI should wait for user input to continue even after headset alignment has been detected as acceptable. This is default mode.
        public const string AutoContinueOnAcceptableHeadsetPosition = "AutoContinueOnAcceptableHeadsetPosition"; // UI should continue automatically to actual calibration after headset alignment has been accepted.
    }

    // Double precision 4x4 matrix.
    // The matrix usage convention is that they are stored in column-major order and transforms are stacked before
    // column-vector points when multiplying. That is, a pure translation matrix will have the position offset in elements 12..14.
    // Unless otherwise specified, the coordinate system is right-handed: X goes right, Y goes up and negative Z goes forward.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoMatrix
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public double[] Value;
    }

    // Double precision 3x3 matrix.
    // The matrix usage convention is that values are stored in column-major order.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoMatrix3x3
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public double[] Value;
    }

    // Ray is a vector starting from an origin.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoRay
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public double[] Origin;   // Origin of the ray.

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public double[] Forward;  // Direction of the ray.
    }

    // 32bit floating point 2D vector.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoVector2Df
    {
        public float x; // X coordinate.
        public float y; // Y coordinate.
    }

    // 64bit floating point 3D vector.

    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoVector3D
    {
        public double x; // X coordinate.
        public double y; // Y coordinate.
        public double z; // Z coordinate.
    }

    // 32bit floating point 3D vector.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoVector3Df
    {
        public float x; // X coordinate.
        public float y; // Y coordinate.
        public float z; // Z coordinate.
    }

    // 32bit integer point 3D vector.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoVector3Di
    {
        public int x; // X coordinate.
        public int y; // Y coordinate.
        public int z; // Z coordinate.
    }

    // 64bit floating point size of a 3D object.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoSize3D
    {
        public double width; // Width along X-axis.
        public double height; // Height along Y-axis.
        public double depth; // Depth along Z-axis.
    }

    // 2D triangle list mesh.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoMesh2Df
    {
        public IntPtr Vertices;   // Pointer to an array of VarjoVector2Df structures.
        public int VertexCount;   // Number of vertices.
    }

    // Axis aligned tangents from a projection matrix.
    // The tangents are between the edge planes and projection centre and defined so that if
    // the projection is centered, all of them are positive.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoAlignedView
    {
        public double projectionTop; // Tangent of the top edge angle.
        public double projectionBottom; // Tangent of the bottom edge angle.
        public double projectionLeft; // Tangent of the left edge angle.
        public double projectionRight; // Tangent of the right edge angle.
    }

    // View information for a frame.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoViewInfo
    {
        public VarjoMatrix projectionMatrix; // The projection matrix.
        public VarjoMatrix viewMatrix; // The view matrix, world-to-eye.
        public int preferredWidth; // Preferred width of the viewport.
        public int preferredHeight; // Preferred height of the viewport.
        public bool enabled; // Whether this view should be rendered during current frame.
        public int reserved; // Unused.
    }

    // Per-frame information.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoFrameInfo
    {
        public IntPtr Views;   // Pointer to an array of VarjoViewInfo structures. The size of the array is obtained by calling varjo_GetViewCount.
        public long DisplayTime;  // When the frame is estimated to be displayed.
        public long FrameNumber;  // Current frame number.
    }


    // View description.
    // Information about the associated eye, display and resolution.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoViewDescription
    {
        public int width; // Default view width in pixels.
        public int height; // Default view height in pixels.
        public VarjoDisplayType display; // Which display the view is for.
        public VarjoEye eye; // Which eye the view is for.
    }

    // Gaze tracker vectors and tracking state.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoGaze
    {
        public VarjoRay leftEye; // Left eye gaze ray.
        public VarjoRay rightEye; // Right eye gaze ray.
        public VarjoRay gaze; // Normalized gaze direction ray.
        public double focusDistance; // Estimated gaze direction focus point distance.
        public double stability; // Focus point stability.
        public long captureTime; // Varjo time when this data was captured.
        public VarjoGazeEyeStatus leftStatus; // Status of left eye data.
        public VarjoGazeEyeStatus rightStatus; // Status of right eye data.
        public VarjoGazeStatus status; // Tracking main status.
        public long frameNumber; // Frame number, increases monotonically.
        public double leftPupilSize; // Normalized [0..1] left eye pupil size.
        public double rightPupilSize; // Normalized [0..1] right eye pupil size.
    }

    // Gaze tracker estimates of user's eye measurements.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoEyeMeasurements
    {
        public long frameNumber; // Frame number, increases monotonically.
        public long captureTime; // Varjo time when this data was captured.
        public float interPupillaryDistanceInMM; // Estimate of user's IPD in mm.
        public float leftPupilIrisDiameterRatio; // Ratio of left pupil to iris diameter in mm. In range [0..1].
        public float rightPupilIrisDiameterRatio; // Ratio of right pupil to iris diameter in mm. In range [0..1].
        public float leftPupilDiameterInMM; // Estimate of left eye pupil diameter in mm.
        public float rightPupilDiameterInMM; // Estimate of right eye pupil diameter in mm.
        public float leftIrisDiameterInMM; // Estimate of left eye iris diameter in mm.
        public float rightIrisDiameterInMM; // Estimate of right eye iris diameter in mm.
        public float leftEyeOpenness; // Estimate of the openness ratio of the left eye; 1 corresponds to a fully open eye and 0 to a fully closed eye.
        public float rightEyeOpenness; // Estimate of the openness ratio of the right eye; 1 corresponds to a fully open eye and 0 to a fully closed eye.
    }

    // Minimum and maximum limits for swap chain texture count and size.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoSwapChainLimits
    {
        public int minimumNumberOfTextures; // Minimum number of swap chain textures.
        public int maximumNumberOfTextures; // Maximum number of swap chain textures.
        public int minimumTextureWidth; // Minimum width of the swap chain textures.
        public int minimumTextureHeight; // Minimum height of the swap chain textures.
        public int maximumTextureWidth; // Maximum width of the swap chain textures.
        public int maximumTextureHeight; // Maximum height of the swap chain textures.
    }

    // Viewport rectangle that defines viewport area.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoViewport
    {
        public int x; // X coordinate for the view in pixels.
        public int y; // Y coordinate for the view in pixels.
        public int width; // Width of the view in pixels.
        public int height; // Height of the view in pixels.
    }

    // API-agnostic texture handle.
    // Use #varjo_FromD3D11Texture, varjo_ToD3D11Texture,
    // #varjo_FromD3D12Texture, #varjo_ToD3D12Texture,
    // #varjo_FromGLTexture, #varjo_ToGLTexture,
    // #varjo_FromVkTexture and #varjo_ToVkTexture
    // to convert textures between Varjo and graphics APIs.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoTexture
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public long[] Reserved;
    };

    // Parameters passed to #varjo_SetInterPupillaryDistanceParameters function.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoInterPupillaryDistanceParameters
    {
        public string key;
        public string value;
    }

    // Parameters passed to #varjo_GazeInitWithParameters function.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoGazeParameters
    {
        public string key;
        public string value;
    }

    // Parameters passed to #varjo_RequestGazeCalibrationWithParameters function.
    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoGazeCalibrationParameters
    {
        public string key;
        public string value;
    }


    public enum VarjoTextureSizeType : long
    {
        BestQuality = 0, // Maximum resolution which provides best possible quality
        Recommended = 1, // Recommended resolution, may not be as large as best quality but still provides great visual results
        Quad = 1, // Resolution for static quad rendering mode
        DynamicFoveation = 2, // Best resolution for foveation mode
        Stereo = 3 // Resolution for stereo mode
    }

    public enum VarjoTextureSizeTypeMask : long
    {
        BestQualityMask = 0x1, // Bitmask for BestQuality texture size type
        RecommendedMask = 0x2, // Bitmask for Recommended texture size type
        QuadMask = 0x2, // Bitmask for Quad texture size type
        DynamicFoveationMask = 0x4, // Bitmask for DynamicFoveation texture size type
        StereoMask = 0x8 // Bitmask for Stereo texture size type
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoFovTangents
    {
        public double top; // Signed tangent of the top FOV half angle
        public double bottom; // Signed tangent of the bottom FOV half angle
        public double left; // Signed tangent of the left FOV half angle
        public double right; // Signed tangent of the right FOV half angle
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoFoveatedFovTangentsHints
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public long[] Reserved;
    }

    public enum VarjoVariableRateShadingFlags : long
    {
        None = 0,
        Stereo = 1, // Generates VRS map for stereo mode (2 views).
        Gaze = 2, // Generates VRS map taking gaze into account.
        GazeCombined = 4, // Generates VRS map taking gaze into account with left and right gaze on one viewport.
        OcclusionMap = 8 // Generates VRS with coarsest shading rate in corners which are not visible.
    }

    public enum VarjoShadingRate : long
    {
        Cull = 0,
        X16PerPixel = 1,
        X8PerPixel = 2,
        X4PerPixel = 3,
        X2PerPixel = 4,
        _1x1 = 5,
        _1x2 = 6,
        _2x1 = 7,
        _2x2 = 8,
        _2x4 = 9,
        _4x2 = 10,
        _4x4 = 11
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VarjoShadingRateTable
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public VarjoShadingRate[] ShadingRates;
    }

    public enum VarjoStructureType : long
    {
    }

    //[StructLayout(LayoutKind.Sequential)]
    //public struct VarjoStructureExtension
    //{
    //    public VarjoStructureType type;
    //    public VarjoStructureExtension next;
    //}

    //[StructLayout(LayoutKind.Sequential)]
    //public struct VarjoVariableRateShadingConfig
    //{
    //    public VarjoStructureExtension next;
    //    public VarjoGaze gaze; // Valid gaze, returned by varjo_GetRenderingGaze().
    //    public int viewIndex; // View for which VRS map should be generated.
    //    public VarjoViewport viewport; // Viewport where VRS map should be generated inside given texture (can be whole texture or a part of it).
    //    public VarjoVariableRateShadingFlags flags;
    //    public float innerRadius; // Radius of the best quality shading rate of the foveated circle if gaze is enabled and calibrated (flags should contain varjo_VariableRateShadingFlag_Gaze). Normalized value between 0 and 1 where 1 is half width of the viewport.
    //    public float outerRadius; // Radius of the outer edge of foveated circle. Medium quality shading rate is generated between range [innerRadius, outerRadius]. Should be bigger than innerRadius. Normalized value between 0 and 1 where 1 is half width of the viewport.
    //}
}
