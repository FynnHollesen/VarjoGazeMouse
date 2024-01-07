using System.Runtime.InteropServices;
using System.Text;

namespace Varjo.NET
{
    internal partial class VarjoInterop
    {
        private const string VARJO_LIB_LIBRARY = "VarjoLib.dll";

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_IsAvailable")]
        internal static extern bool IsAvailable();

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetVersionString")]
        internal static extern IntPtr GetVersionString();

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetVersion")]
        internal static extern ulong GetVersion();

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_SessionInit")]
        internal static extern IntPtr SessionInit();

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_SessionShutDown")]
        internal static extern void SessionShutDown(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_SessionSetPriority")]
        internal static extern void SessionSetPriority(IntPtr session, int priority);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetCurrentTime")]
        internal static extern long GetCurrentTime(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_CreateFrameInfo")]
        internal static extern IntPtr CreateFrameInfo(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_FreeFrameInfo")]
        internal static extern void FreeFrameInfo(IntPtr frameInfo);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_SetCenteredProjection")]
        internal static extern void SetCenteredProjection(IntPtr session, bool enabled);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetViewCount")]
        internal static extern int GetViewCount(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetAlignedView")]
        internal static extern VarjoAlignedView GetAlignedView(ref double projectionMatrix);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_WaitSync")]
        internal static extern void WaitSync(IntPtr session, IntPtr frameInfo);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_WaitSync")]
        internal static extern void WaitSync(IntPtr session, ref VarjoFrameInfo frameInfo);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_FrameGetDisplayTime")]
        internal static extern long FrameGetDisplayTime(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_FrameGetPose")]
        internal static extern VarjoMatrix FrameGetPose(IntPtr session, VarjoPoseType type);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetTrackingToLocalTransform")]
        internal static extern VarjoMatrix GetTrackingToLocalTransform(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetRelativePoseTransform")]
        internal static extern VarjoMatrix GetRelativePoseTransform(IntPtr session, VarjoPoseType src, VarjoPoseType dest);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_ApplyTransform")]
        internal static extern VarjoMatrix ApplyTransform(IntPtr session, ref VarjoMatrix m1, ref VarjoMatrix m2);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_ApplyTransform")]
        internal static extern VarjoMatrix ApplyTransform(IntPtr session, IntPtr m1, IntPtr m2);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_ResetPose")]
        internal static extern void ResetPose(IntPtr session, bool position, VarjoRotationReset rotation);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetViewDescription")]
        internal static extern VarjoViewDescription GetViewDescription(IntPtr session, int viewIndex);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_CreateOcclusionMesh")]
        internal static extern IntPtr CreateOcclusionMesh(IntPtr session, int viewIndex, VarjoWindingOrder windingOrder);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_FreeOcclusionMesh")]
        internal static extern void FreeOcclusionMesh(IntPtr mesh);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetError")]
        internal static extern VarjoError GetError(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetErrorDesc")]
        internal static extern IntPtr GetErrorDesc(VarjoError error);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GazeInit")]
        internal static extern void GazeInit(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GazeInitWithParameters")]
        internal static extern void GazeInitWithParameters(IntPtr session, IntPtr parameters, int parameterCount);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GazeInitWithParameters")]
        internal static extern void GazeInitWithParameters(IntPtr session, ref VarjoGazeParameters parameters, int parameterCount);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GazeInitWithParameters")]
        internal static extern void GazeInitWithParameters(IntPtr session, [In, Out] VarjoGazeParameters[] parameters, int parameterCount);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_IsGazeAllowed")]
        internal static extern bool IsGazeAllowed(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_RequestGazeCalibration")]
        internal static extern void RequestGazeCalibration(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_RequestGazeCalibrationWithParameters")]
        internal static extern void RequestGazeCalibrationWithParameters(IntPtr session, IntPtr parameters, int parameterCount);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_RequestGazeCalibrationWithParameters")]
        internal static extern void RequestGazeCalibrationWithParameters(IntPtr session, ref VarjoGazeCalibrationParameters parameters, int parameterCount);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_RequestGazeCalibrationWithParameters")]
        internal static extern void RequestGazeCalibrationWithParameters(IntPtr session, [In, Out] VarjoGazeCalibrationParameters[] parameters, int parameterCount);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetGaze")]
        internal static extern VarjoGaze GetGaze(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetGazeData")]
        internal static extern bool GetGazeData(IntPtr session, IntPtr gaze, IntPtr eyeMeasurements);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetGazeData")]
        internal static extern bool GetGazeData(IntPtr session, ref VarjoGaze gaze, ref VarjoEyeMeasurements eyeMeasurements);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetGazeArray")]
        internal static extern int GetGazeArray(IntPtr session, IntPtr array, int maxSize);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetGazeArray")]
        internal static extern int GetGazeArray(IntPtr session, [In, Out] VarjoGaze[] array, int maxSize);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetGazeDataArray")]
        internal static extern int GetGazeDataArray(IntPtr session, IntPtr gazeArray, IntPtr eyeMeasurementsArray, int maxSize);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetGazeDataArray")]
        internal static extern int GetGazeDataArray(IntPtr session, [In, Out] VarjoGaze[] gazeArray, ref VarjoEyeMeasurements eyeMeasurementsArray, int maxSize);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_SyncProperties")]
        internal static extern void SyncProperties(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetPropertyCount")]
        internal static extern int GetPropertyCount(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetPropertyKey")]
        internal static extern VarjoPropertyKey GetPropertyKey(IntPtr session, int index);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetPropertyName")]
        internal static extern IntPtr GetPropertyName(IntPtr session, VarjoPropertyKey propertyKey);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_HasProperty")]
        internal static extern bool HasProperty(IntPtr session, VarjoPropertyKey propertyKey);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetPropertyBool")]
        internal static extern bool GetPropertyBool(IntPtr session, VarjoPropertyKey propertyKey);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetPropertyDouble")]
        internal static extern double GetPropertyDouble(IntPtr session, VarjoPropertyKey propertyKey);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetPropertyInt")]
        internal static extern int GetPropertyInt(IntPtr session, VarjoPropertyKey propertyKey);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetPropertyString")]
        internal static extern void GetPropertyString(IntPtr session, VarjoPropertyKey propertyKey, StringBuilder buffer, uint maxSize);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetPropertyStringSize")]
        internal static extern uint GetPropertyStringSize(IntPtr session, VarjoPropertyKey propertyKey);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetSwapChainLimits")]
        internal static extern VarjoSwapChainLimits GetSwapChainLimits(IntPtr session);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetSupportedTextureFormats")]
        internal static extern void GetSupportedTextureFormats(IntPtr session, VarjoRenderAPI renderApi, ref int formatCount, IntPtr formats);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetSupportedTextureFormats")]
        internal static extern void GetSupportedTextureFormats(IntPtr session, VarjoRenderAPI renderApi, ref int formatCount, [In, Out] VarjoTextureFormat[] formats);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_AllocateEvent")]
        internal static extern IntPtr AllocateEvent();

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_FreeEvent")]
        internal static extern void FreeEvent(IntPtr @event);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_PollEvent")]
        internal static extern bool PollEvent(IntPtr session, IntPtr evt);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetTextureSize")]
        internal static extern void GetTextureSize(IntPtr session, VarjoTextureSizeType type, int viewIndex, ref int width, ref int height);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_D3D12UpdateVariableRateShadingTexture")]
        internal static extern void D3D12UpdateVariableRateShadingTexture(IntPtr session, IntPtr commandList, IntPtr texture, IntPtr config);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_D3D11UpdateVariableRateShadingTexture")]
        internal static extern void D3D11UpdateVariableRateShadingTexture(IntPtr session, IntPtr device, IntPtr texture, IntPtr config, IntPtr shadingRateTable);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GLUpdateVariableRateShadingTexture")]
        internal static extern void GLUpdateVariableRateShadingTexture(IntPtr session, uint texture, int width, int height, IntPtr config, IntPtr shadingRateTable);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetRenderingGaze")]
        internal static extern bool GetRenderingGaze(IntPtr session, IntPtr gaze);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetRenderingGaze")]
        internal static extern bool GetRenderingGaze(IntPtr session, ref VarjoGaze gaze);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetFoveatedFovTangents")]
        internal static extern VarjoFovTangents GetFoveatedFovTangents(IntPtr session, int viewIndex, IntPtr gaze, IntPtr hints);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetFoveatedFovTangents")]
        internal static extern VarjoFovTangents GetFoveatedFovTangents(IntPtr session, int viewIndex, ref VarjoGaze gaze, ref VarjoFoveatedFovTangentsHints hints);

        [DllImport(VARJO_LIB_LIBRARY, EntryPoint = "varjo_GetFovTangents")]
        internal static extern VarjoFovTangents GetFovTangents(IntPtr session, int viewIndex);
    }
}
