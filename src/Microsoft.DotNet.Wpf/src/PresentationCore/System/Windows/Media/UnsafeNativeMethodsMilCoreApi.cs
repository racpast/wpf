// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

//  ABOUT THIS FILE:
//   -- This file contains native methods which are deemed NOT SAFE in the sense that any usage of them
//      must be carefully reviewed.   FXCop will flag callers of these for review.
//   -- These methods DO have the SuppressUnmanagedCodeSecurity attribute which means stalk walks for unmanaged
//      code will stop with the immediate caler.
//   -- Put methods in here when a stack walk is innappropriate due to performance concerns

using System;
using System.Runtime.InteropServices;
using MS.Internal;
using System.Text;
using System.Windows.Media.Composition;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;

namespace MS.Win32.PresentationCore
{
    internal static partial class UnsafeNativeMethods
    {
        internal static partial class MilCoreApi
        {
            [LibraryImport(DllImport.MilCore, EntryPoint = "MilCompositionEngine_EnterCompositionEngineLock")]
            internal static partial void EnterCompositionEngineLock();

            [LibraryImport(DllImport.MilCore, EntryPoint = "MilCompositionEngine_ExitCompositionEngineLock")]
            internal static partial void ExitCompositionEngineLock();

            [LibraryImport(DllImport.MilCore, EntryPoint = "MilCompositionEngine_EnterMediaSystemLock")]
            internal static partial void EnterMediaSystemLock();

            [LibraryImport(DllImport.MilCore, EntryPoint = "MilCompositionEngine_ExitMediaSystemLock")]
            internal static partial void ExitMediaSystemLock();

            [LibraryImport(DllImport.MilCore)]
            internal static partial int MilVersionCheck(
                uint uiCallerMilSdkVersion
             );
 
            [LibraryImport(DllImport.MilCore)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static partial bool WgxConnection_ShouldForceSoftwareForGraphicsStreamClient();

            [LibraryImport(DllImport.MilCore)]
            internal static partial int WgxConnection_Create(
                [MarshalAs(UnmanagedType.Bool)] bool requestSynchronousTransport,
                out IntPtr ppConnection);

            [LibraryImport(DllImport.MilCore)]
            internal static partial int WgxConnection_Disconnect(IntPtr pTranspManager);

            [LibraryImport(DllImport.MilCore)]
            internal static partial int /* HRESULT */ MILCreateStreamFromStreamDescriptor(ref System.Windows.Media.StreamDescriptor pSD, out IntPtr ppStream);

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe void MilUtility_GetTileBrushMapping(
                D3DMATRIX* transform,
                D3DMATRIX* relativeTransform,
                Stretch stretch,
                AlignmentX alignmentX,
                AlignmentY alignmentY,
                BrushMappingMode viewPortUnits,
                BrushMappingMode viewBoxUnits,
                Rect* shapeFillBounds,
                Rect* contentBounds,
                ref Rect viewport,
                ref Rect viewbox,
                out D3DMATRIX contentToShape,
                out int brushIsEmpty
                );

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilUtility_PathGeometryBounds(
                MIL_PEN_DATA *pPenData,
                double *pDashArray,
                MilMatrix3x2D* pWorldMatrix,
                FillRule fillRule,
                byte* pPathData,
                UInt32 nSize,
                MilMatrix3x2D* pGeometryMatrix,
                double rTolerance,
                [MarshalAs(UnmanagedType.Bool)] bool fRelative,
                [MarshalAs(UnmanagedType.Bool)] bool fSkipHollows,
                MilRectD* pBounds);

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilUtility_PathGeometryCombine(
                MilMatrix3x2D* pMatrix,
                MilMatrix3x2D* pMatrix1,
                FillRule fillRule1,
                byte* pPathData1,
                UInt32 nSize1,
                MilMatrix3x2D* pMatrix2,
                FillRule fillRule2,
                byte* pPathData2,
                UInt32 nSize2,
                double rTolerance,
                [MarshalAs(UnmanagedType.Bool)] bool fRelative,
                PathGeometry.AddFigureToListDelegate addFigureCallback,
                GeometryCombineMode combineMode,
                out FillRule resultFillRule);

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilUtility_PathGeometryWiden(
                MIL_PEN_DATA *pPenData,
                double *pDashArray,
                MilMatrix3x2D* pMatrix,
                FillRule fillRule,
                byte* pPathData,
                UInt32 nSize,
                double rTolerance,
                [MarshalAs(UnmanagedType.Bool)] bool fRelative,
                PathGeometry.AddFigureToListDelegate addFigureCallback,
                out FillRule widenedFillRule);

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilUtility_PathGeometryOutline(
                MilMatrix3x2D* pMatrix,
                FillRule fillRule,
                byte* pPathData,
                UInt32 nSize,
                double rTolerance,
                [MarshalAs(UnmanagedType.Bool)] bool fRelative,
                PathGeometry.AddFigureToListDelegate addFigureCallback,
                out FillRule outlinedFillRule);

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilUtility_PathGeometryFlatten(
                MilMatrix3x2D* pMatrix,
                FillRule fillRule,
                byte* pPathData,
                UInt32 nSize,
                double rTolerance,
                [MarshalAs(UnmanagedType.Bool)] bool fRelative,
                PathGeometry.AddFigureToListDelegate addFigureCallback,
                out FillRule resultFillRule);

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilGlyphCache_BeginCommandAtRenderTime(
                IntPtr pMilSlaveGlyphCacheTarget,
                byte* pbData,
                uint cbSize,
                uint cbExtra
                );

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilGlyphCache_AppendCommandDataAtRenderTime(
                IntPtr pMilSlaveGlyphCacheTarget,
                byte* pbData,
                uint cbSize
                );

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilGlyphCache_EndCommandAtRenderTime(
                IntPtr pMilSlaveGlyphCacheTarget
                );

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilGlyphRun_SetGeometryAtRenderTime(
                IntPtr pMilGlyphRunTarget,
                byte* pCmd,
                uint cbCmd
                );

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilGlyphRun_GetGlyphOutline(
                IntPtr pFontFace,
                ushort glyphIndex, 
                [MarshalAs(UnmanagedType.Bool)] bool sideways, 
                double renderingEmSize,
                out byte* pPathGeometryData,
                out UInt32 pSize,
                out FillRule pFillRule
                );

            [LibraryImport(DllImport.MilCore)]
            internal static partial unsafe int MilGlyphRun_ReleasePathGeometryData(
                byte* pPathGeometryData
                );

            [LibraryImport(DllImport.MilCore, EntryPoint = "MilCreateReversePInvokeWrapper")]
            internal static partial unsafe /*HRESULT*/ int MilCreateReversePInvokeWrapper(
                IntPtr pFcn, 
                out IntPtr reversePInvokeWrapper);

            [LibraryImport(DllImport.MilCore, EntryPoint = "MilReleasePInvokePtrBlocking")]
            internal static partial unsafe void MilReleasePInvokePtrBlocking(
                IntPtr reversePInvokeWrapper);

            [LibraryImport(DllImport.MilCore, EntryPoint = "RenderOptions_ForceSoftwareRenderingModeForProcess")]
            internal static partial unsafe void RenderOptions_ForceSoftwareRenderingModeForProcess(
                [MarshalAs(UnmanagedType.Bool)] bool fForce);

            [LibraryImport(DllImport.MilCore, EntryPoint = "RenderOptions_IsSoftwareRenderingForcedForProcess")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static partial unsafe bool RenderOptions_IsSoftwareRenderingForcedForProcess();

            [LibraryImport(DllImport.MilCore, EntryPoint = "RenderOptions_EnableHardwareAccelerationInRdp")]
            internal static partial unsafe void RenderOptions_EnableHardwareAccelerationInRdp([MarshalAs(UnmanagedType.Bool)] bool value);                 

            [LibraryImport(DllImport.MilCore, EntryPoint = "MilResource_CreateCWICWrapperBitmap")]
            internal static partial unsafe int /* HRESULT */ CreateCWICWrapperBitmap(
                BitmapSourceSafeMILHandle /* IWICBitmapSource */ pIWICBitmapSource,
                out BitmapSourceSafeMILHandle /* CWICWrapperBitmap as IWICBitmapSource */ pCWICWrapperBitmap);
        }

        internal static partial class WICComponentInfo
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICComponentInfo_GetCLSID_Proxy")]
            internal static partial int /* HRESULT */ GetCLSID(
                System.Windows.Media.SafeMILHandle /* IWICComponentInfo */ THIS_PTR,
                out Guid pclsid);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICComponentInfo_GetAuthor_Proxy")]
            internal static partial int /* HRESULT */ GetAuthor(
                System.Windows.Media.SafeMILHandle /* IWICComponentInfo */ THIS_PTR,
                UInt32 cchAuthor,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte, SizeParamIndex = 1)] char[] wzAuthor,
                out UInt32 pcchActual);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICComponentInfo_GetVersion_Proxy")]
            internal static partial int /* HRESULT */ GetVersion(
                System.Windows.Media.SafeMILHandle /* IWICComponentInfo */ THIS_PTR,
                UInt32 cchVersion,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte, SizeParamIndex = 1)] char[] wzVersion,
                out UInt32 pcchActual);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICComponentInfo_GetSpecVersion_Proxy")]
            internal static partial int /* HRESULT */ GetSpecVersion(
                System.Windows.Media.SafeMILHandle /* IWICComponentInfo */ THIS_PTR,
                UInt32 cchSpecVersion,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte, SizeParamIndex = 1)] char[] wzSpecVersion,
                out UInt32 pcchActual);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICComponentInfo_GetFriendlyName_Proxy")]
            internal static partial int /* HRESULT */ GetFriendlyName(
                System.Windows.Media.SafeMILHandle /* IWICComponentInfo */ THIS_PTR,
                UInt32 cchFriendlyName,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte, SizeParamIndex = 1)] char[] wzFriendlyName,
                out UInt32 pcchActual);
        }

        internal static partial class WICBitmapCodecInfo
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapCodecInfo_GetContainerFormat_Proxy")]
            internal static partial int /* HRESULT */ GetContainerFormat(
                System.Windows.Media.SafeMILHandle /* IWICBitmapCodecInfo */ THIS_PTR,
                out Guid pguidContainerFormat);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapCodecInfo_GetDeviceManufacturer_Proxy")]
            internal static partial int /* HRESULT */ GetDeviceManufacturer(
                System.Windows.Media.SafeMILHandle /* IWICBitmapCodecInfo */ THIS_PTR,
                UInt32 cchDeviceManufacturer,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte, SizeParamIndex = 1)] char[] wzDeviceManufacturer,
                out UInt32 pcchActual
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapCodecInfo_GetDeviceModels_Proxy")]
            internal static partial int /* HRESULT */ GetDeviceModels(
                System.Windows.Media.SafeMILHandle /* IWICBitmapCodecInfo */ THIS_PTR,
                UInt32 cchDeviceModels,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte, SizeParamIndex = 1)] char[] wzDeviceModels,
                out UInt32 pcchActual
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapCodecInfo_GetMimeTypes_Proxy")]
            internal static partial int /* HRESULT */ GetMimeTypes(
                System.Windows.Media.SafeMILHandle /* IWICBitmapCodecInfo */ THIS_PTR,
                UInt32 cchMimeTypes,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte, SizeParamIndex = 1)] char[] wzMimeTypes,
                out UInt32 pcchActual
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapCodecInfo_GetFileExtensions_Proxy")]
            internal static partial int /* HRESULT */ GetFileExtensions(
                System.Windows.Media.SafeMILHandle /* IWICBitmapCodecInfo */ THIS_PTR,
                UInt32 cchFileExtensions,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte, SizeParamIndex = 1)] char[] wzFileExtensions,
                out UInt32 pcchActual
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapCodecInfo_DoesSupportAnimation_Proxy")]
            internal static partial int /* HRESULT */ DoesSupportAnimation(
                System.Windows.Media.SafeMILHandle /* IWICBitmapCodecInfo */ THIS_PTR,
                [MarshalAs(UnmanagedType.Bool)] out bool pfSupportAnimation
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapCodecInfo_DoesSupportLossless_Proxy")]
            internal static partial int /* HRESULT */ DoesSupportLossless(
                System.Windows.Media.SafeMILHandle /* IWICBitmapCodecInfo */ THIS_PTR,
                [MarshalAs(UnmanagedType.Bool)] out bool pfSupportLossless
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapCodecInfo_DoesSupportMultiframe_Proxy")]
            internal static partial int /* HRESULT */ DoesSupportMultiframe(
                System.Windows.Media.SafeMILHandle /* IWICBitmapCodecInfo */ THIS_PTR,
                [MarshalAs(UnmanagedType.Bool)] out bool pfSupportMultiframe
                );
        }

        internal static partial class WICMetadataQueryReader
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICMetadataQueryReader_GetContainerFormat_Proxy")]
            internal static partial int /* HRESULT */ GetContainerFormat(
                System.Windows.Media.SafeMILHandle /* IWICMetadataQueryReader */ THIS_PTR,
                out Guid pguidContainerFormat);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICMetadataQueryReader_GetLocation_Proxy")]
            internal static partial int /* HRESULT */ GetLocation(
                System.Windows.Media.SafeMILHandle /* IWICMetadataQueryReader */ THIS_PTR,
                UInt32 cchLocation,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte, SizeParamIndex = 1)] char[] wzNamespace,
                out UInt32 pcchActual
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICMetadataQueryReader_GetMetadataByName_Proxy", StringMarshalling = StringMarshalling.Utf16)]
            internal static partial int /* HRESULT */ GetMetadataByName(
                System.Windows.Media.SafeMILHandle /* IWICMetadataQueryReader */ THIS_PTR,
                string wzName,
                ref System.Windows.Media.Imaging.PROPVARIANT propValue
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICMetadataQueryReader_GetMetadataByName_Proxy", StringMarshalling = StringMarshalling.Utf16)]
            internal static partial int /* HRESULT */ ContainsMetadataByName(
                System.Windows.Media.SafeMILHandle /* IWICMetadataQueryReader */ THIS_PTR,
                string wzName,
                IntPtr propVar
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICMetadataQueryReader_GetEnumerator_Proxy")]
            internal static partial int /* HRESULT */ GetEnumerator(
                System.Windows.Media.SafeMILHandle /* IWICMetadataQueryReader */ THIS_PTR,
                out System.Windows.Media.SafeMILHandle /* IEnumString */ enumString
                );
        }

        internal static partial class WICMetadataQueryWriter
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICMetadataQueryWriter_SetMetadataByName_Proxy", StringMarshalling = StringMarshalling.Utf16)]
            internal static partial int /* HRESULT */ SetMetadataByName(
                System.Windows.Media.SafeMILHandle /* IWICMetadataQueryWriter */ THIS_PTR,
                string wzName,
                ref System.Windows.Media.Imaging.PROPVARIANT propValue
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICMetadataQueryWriter_RemoveMetadataByName_Proxy", StringMarshalling = StringMarshalling.Utf16)]
            internal static partial int /* HRESULT */ RemoveMetadataByName(
                System.Windows.Media.SafeMILHandle /* IWICMetadataQueryWriter */ THIS_PTR,
                string wzName
                );
        }

        internal static partial class WICFastMetadataEncoder
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICFastMetadataEncoder_Commit_Proxy")]
            internal static partial int /* HRESULT */ Commit(
                System.Windows.Media.SafeMILHandle /* IWICFastMetadataEncoder */ THIS_PTR
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICFastMetadataEncoder_GetMetadataQueryWriter_Proxy")]
            internal static partial int /* HRESULT */ GetMetadataQueryWriter(
                System.Windows.Media.SafeMILHandle /* IWICFastMetadataEncoder */ THIS_PTR,
                out SafeMILHandle /* IWICMetadataQueryWriter */ ppIQueryWriter
                );
        }

        internal static partial class EnumString
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IEnumString_Next_WIC_Proxy")]
            internal static partial int /* HRESULT */ Next(
                System.Windows.Media.SafeMILHandle /* IEnumString */ THIS_PTR,
                Int32 celt,
                ref IntPtr rgElt,
                ref Int32 pceltFetched
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IEnumString_Reset_WIC_Proxy")]
            internal static partial int /* HRESULT */ Reset(
                System.Windows.Media.SafeMILHandle /* IEnumString */ THIS_PTR
                );
        }

        internal static partial class IPropertyBag2
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IPropertyBag2_Write_Proxy")]
            internal static partial int /* HRESULT */ Write(
                System.Windows.Media.SafeMILHandle /* IPropertyBag2 */ THIS_PTR,
                UInt32 cProperties,
                ref System.Windows.Media.Imaging.PROPBAG2 propBag,
                ref System.Windows.Media.Imaging.PROPVARIANT propValue
                );
        }

        internal static partial class WICBitmapSource
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapSource_GetSize_Proxy")]
            internal static partial int /* HRESULT */ GetSize(
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource */ THIS_PTR,
                out UInt32 puiWidth,
                out UInt32 puiHeight);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapSource_GetPixelFormat_Proxy")]
            internal static partial int /* HRESULT */ GetPixelFormat(
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource */ THIS_PTR,
                out Guid pPixelFormatEnum);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapSource_GetResolution_Proxy")]
            internal static partial int /* HRESULT */ GetResolution(
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource */ THIS_PTR,
                out double pDpiX,
                out double pDpiY);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapSource_CopyPalette_Proxy")]
            internal static partial int /* HRESULT */ CopyPalette(
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IMILPalette */ pIPalette);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapSource_CopyPixels_Proxy")]
            internal static partial int /* HRESULT */ CopyPixels(
                SafeMILHandle /* IWICBitmapSource */ THIS_PTR,
                ref Int32Rect prc,
                UInt32 cbStride,
                UInt32 cbBufferSize,
                IntPtr /* BYTE* */ pvPixels);
        }

        internal static partial class WICBitmapDecoder
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapDecoder_GetDecoderInfo_Proxy")]
            internal static partial int /* HRESULT */ GetDecoderInfo(
                SafeMILHandle THIS_PTR,
                out SafeMILHandle /* IWICBitmapDecoderInfo */ ppIDecoderInfo);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapDecoder_CopyPalette_Proxy")]
            internal static partial int /* HRESULT */ CopyPalette(
                SafeMILHandle /* IWICBitmapDecoder */ THIS_PTR,
                SafeMILHandle /* IMILPalette */ pIPalette);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapDecoder_GetPreview_Proxy")]
            internal static partial int /* HRESULT */ GetPreview(
                SafeMILHandle THIS_PTR,
                out IntPtr /* IWICBitmapSource */ ppIBitmapSource
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapDecoder_GetColorContexts_Proxy")]
            internal static partial int /* HRESULT */ GetColorContexts(
                SafeMILHandle THIS_PTR,
                uint count,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] /* IWICColorContext */ ppIColorContext,
                out uint pActualCount
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapDecoder_GetThumbnail_Proxy")]
            internal static partial int /* HRESULT */ GetThumbnail(
                SafeMILHandle /* IWICBitmapDecoder */ THIS_PTR,
                out IntPtr /* IWICBitmapSource */ ppIThumbnail
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapDecoder_GetMetadataQueryReader_Proxy")]
            internal static partial int /* HRESULT */ GetMetadataQueryReader(
                SafeMILHandle /* IWICBitmapDecoder */ THIS_PTR,
                out IntPtr /* IWICMetadataQueryReader */ ppIQueryReader
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapDecoder_GetFrameCount_Proxy")]
            internal static partial int /* HRESULT */ GetFrameCount(
                SafeMILHandle THIS_PTR,
                out uint pFrameCount
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapDecoder_GetFrame_Proxy")]
            internal static partial int /* HRESULT */ GetFrame(
                SafeMILHandle /* IWICBitmapDecoder */ THIS_PTR,
                UInt32 index,
                out IntPtr /* IWICBitmapFrameDecode */ ppIFrameDecode
                );
        }

        internal static partial class WICBitmapFrameDecode
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapFrameDecode_GetThumbnail_Proxy")]
            internal static partial int /* HRESULT */ GetThumbnail(
                SafeMILHandle /* IWICBitmapFrameDecode */ THIS_PTR,
                out IntPtr /* IWICBitmap */ ppIThumbnail
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapFrameDecode_GetMetadataQueryReader_Proxy")]
            internal static partial int /* HRESULT */ GetMetadataQueryReader(
                SafeMILHandle /* IWICBitmapFrameDecode */ THIS_PTR,
                out IntPtr /* IWICMetadataQueryReader */ ppIQueryReader
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapFrameDecode_GetColorContexts_Proxy")]
            internal static partial int /* HRESULT */ GetColorContexts(
                SafeMILHandle /* IWICBitmapFrameDecode */ THIS_PTR,
                uint count,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] /* IWICColorContext */ ppIColorContext,
                out uint pActualCount
                );
        }

        internal static partial class MILUnknown
        {
            [LibraryImport(DllImport.MilCore, EntryPoint = "MILAddRef")]
            internal static partial UInt32 AddRef(SafeMILHandle pIUnkown);

            [LibraryImport(DllImport.MilCore, EntryPoint = "MILAddRef")]
            internal static partial UInt32 AddRef(SafeReversePInvokeWrapper pIUnknown);

            [LibraryImport(DllImport.MilCore, EntryPoint = "MILRelease")]
            internal static partial int Release(IntPtr pIUnkown);

            internal static void ReleaseInterface(ref IntPtr ptr)
            {
                if (ptr != IntPtr.Zero)
                {
                    // Return value ignored on purpose.
                    UnsafeNativeMethods.MILUnknown.Release(ptr);
                    ptr = IntPtr.Zero;
                }
            }

            [LibraryImport(DllImport.MilCore, EntryPoint = "MILQueryInterface")]
            internal static partial int /* HRESULT */ QueryInterface(
                IntPtr pIUnknown,
                ref Guid guid,
                out IntPtr ppvObject);

            [LibraryImport(DllImport.MilCore, EntryPoint = "MILQueryInterface")]
            internal static partial int /* HRESULT */ QueryInterface(
                SafeMILHandle pIUnknown,
                ref Guid guid,
                out IntPtr ppvObject);
        }

        internal static partial class WICStream
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICStream_InitializeFromIStream_Proxy")]
            internal static partial int /*HRESULT*/ InitializeFromIStream(
                IntPtr pIWICStream,
                IntPtr pIStream);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICStream_InitializeFromMemory_Proxy")]
            internal static partial int /*HRESULT*/ InitializeFromMemory(
                IntPtr pIWICStream,
                IntPtr pbBuffer,
                uint cbSize);
        }

        internal static partial class WindowsCodecApi
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "WICCreateBitmapFromSection")]
            internal static partial int /*HRESULT*/ CreateBitmapFromSection(
                UInt32 width,
                UInt32 height,
                ref Guid pixelFormatGuid,
                IntPtr hSection,
                UInt32 stride,
                UInt32 offset,
                out BitmapSourceSafeMILHandle /* IWICBitmap */ ppIBitmap);
        }

        internal static partial class WICBitmapFrameEncode
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapFrameEncode_Initialize_Proxy")]
            internal static partial int /* HRESULT */ Initialize(SafeMILHandle /* IWICBitmapFrameEncode* */ THIS_PTR,
                SafeMILHandle /* IPropertyBag2* */ pIEncoderOptions);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapFrameEncode_Commit_Proxy")]
            internal static partial int /* HRESULT */ Commit(SafeMILHandle /* IWICBitmapFrameEncode* */ THIS_PTR);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapFrameEncode_SetSize_Proxy")]
            internal static partial int /* HRESULT */ SetSize(SafeMILHandle /* IWICBitmapFrameEncode* */ THIS_PTR,
                int width,
                int height);

           [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapFrameEncode_SetResolution_Proxy")]
           internal static partial int /* HRESULT */ SetResolution(SafeMILHandle /* IWICBitmapFrameEncode* */ THIS_PTR,
               double dpiX,
               double dpiY);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapFrameEncode_WriteSource_Proxy")]
            internal static partial int /* HRESULT */ WriteSource(SafeMILHandle /* IWICBitmapFrameEncode* */ THIS_PTR,
                SafeMILHandle /* IWICBitmapSource* */ pIBitmapSource,
                ref Int32Rect /* MILRect* */ r);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapFrameEncode_SetThumbnail_Proxy")]
            internal static partial int /* HRESULT */ SetThumbnail(SafeMILHandle /* IWICBitmapFrameEncode* */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource* */ pIThumbnail);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapFrameEncode_GetMetadataQueryWriter_Proxy")]
            internal static partial int /* HRESULT */ GetMetadataQueryWriter(
                SafeMILHandle /* IWICBitmapFrameEncode */ THIS_PTR,
                out SafeMILHandle /* IWICMetadataQueryWriter */ ppIQueryWriter
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapFrameEncode_SetColorContexts_Proxy")]
            internal static partial int /* HRESULT */ SetColorContexts(SafeMILHandle /* IWICBitmapEncoder* */ THIS_PTR,
                    uint nIndex,
                    [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] /* IWICColorContext */ ppIColorContext
                    );
        }

        internal static partial class WICBitmapEncoder
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapEncoder_Initialize_Proxy")]
            internal static partial int /* HRESULT */ Initialize(SafeMILHandle /* IWICBitmapEncoder* */ THIS_PTR,
                IntPtr /* IStream */ pStream,
                WICBitmapEncodeCacheOption option);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapEncoder_GetEncoderInfo_Proxy")]
            internal static partial int /* HRESULT */ GetEncoderInfo(SafeMILHandle /* IWICBitmapEncoder* */ THIS_PTR,
                out SafeMILHandle /* IWICBitmapEncoderInfo ** */ ppIEncoderInfo
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapEncoder_CreateNewFrame_Proxy")]
            internal static partial int /* HRESULT */ CreateNewFrame(SafeMILHandle /* IWICBitmapEncoder* */ THIS_PTR,
                out SafeMILHandle /* IWICBitmapFrameEncode ** */ ppIFramEncode,
                out SafeMILHandle /* IPropertyBag2 ** */ ppIEncoderOptions
            );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapEncoder_SetThumbnail_Proxy")]
            internal static partial int /* HRESULT */ SetThumbnail(SafeMILHandle /* IWICBitmapEncoder* */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource* */ pIThumbnail);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapEncoder_SetPalette_Proxy")]
            internal static partial int /* HRESULT */ SetPalette(SafeMILHandle /* IWICBitmapEncoder* */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IWICPalette* */ pIPalette);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapEncoder_GetMetadataQueryWriter_Proxy")]
            internal static partial int /* HRESULT */ GetMetadataQueryWriter(
                SafeMILHandle /* IWICBitmapEncoder */ THIS_PTR,
                out SafeMILHandle /* IWICMetadataQueryWriter */ ppIQueryWriter
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICBitmapEncoder_Commit_Proxy")]
            internal static partial int /* HRESULT */ Commit(SafeMILHandle /* IWICBitmapEncoder* */ THIS_PTR);
        }

        internal static partial class WICPalette
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICPalette_InitializePredefined_Proxy")]
            internal static partial int /* HRESULT */ InitializePredefined(System.Windows.Media.SafeMILHandle /* IWICPalette */ THIS_PTR,
                WICPaletteType ePaletteType,
                [MarshalAs(UnmanagedType.Bool)] bool fAddTransparentColor);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICPalette_InitializeCustom_Proxy")]
            internal static partial int /* HRESULT */ InitializeCustom(System.Windows.Media.SafeMILHandle /* IWICPalette */ THIS_PTR,
                IntPtr /* MILColor* */ pColors,
                int colorCount);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICPalette_InitializeFromBitmap_Proxy")]
            internal static partial int /* HRESULT */ InitializeFromBitmap(System.Windows.Media.SafeMILHandle /* IWICPalette */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource* */ pISurface,
                int colorCount,
                [MarshalAs(UnmanagedType.Bool)] bool fAddTransparentColor);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICPalette_InitializeFromPalette_Proxy")]
            internal static partial int /* HRESULT */ InitializeFromPalette(IntPtr /* IWICPalette */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IWICPalette */ pIWICPalette);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICPalette_GetType_Proxy")]
            internal static partial int /* HRESULT */ GetType(System.Windows.Media.SafeMILHandle /* IWICPalette */ THIS_PTR,
                out WICPaletteType pePaletteType);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICPalette_GetColorCount_Proxy")]
            internal static partial int /* HRESULT */ GetColorCount(System.Windows.Media.SafeMILHandle /* IWICPalette */ THIS_PTR,
                out int pColorCount);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICPalette_GetColors_Proxy")]
            internal static partial int /* HRESULT */ GetColors(System.Windows.Media.SafeMILHandle /* IWICPalette */ THIS_PTR,
                int colorCount,
                IntPtr /* MILColor* */ pColors,
                out int pcActualCount);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint="IWICPalette_HasAlpha_Proxy")]
            internal static partial int /* HRESULT */ HasAlpha(System.Windows.Media.SafeMILHandle /* IWICPalette */ THIS_PTR,
                   [MarshalAs(UnmanagedType.Bool)] out bool pfHasAlpha);
        }

        internal static partial class WICImagingFactory
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateDecoderFromStream_Proxy")]
            internal static partial int /*HRESULT*/ CreateDecoderFromStream(
                IntPtr pICodecFactory,
                IntPtr /* IStream */ pIStream,
                ref Guid guidVendor,
                UInt32 metadataFlags,
                out IntPtr /* IWICBitmapDecoder */ ppIDecode);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateDecoderFromFileHandle_Proxy")]
            internal static partial int /*HRESULT*/ CreateDecoderFromFileHandle(
                IntPtr pICodecFactory,
                Microsoft.Win32.SafeHandles.SafeFileHandle  /*ULONG_PTR*/ hFileHandle,
                ref Guid guidVendor,
                UInt32 metadataFlags,
                out IntPtr /* IWICBitmapDecoder */ ppIDecode);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateComponentInfo_Proxy")]
            internal static partial int /*HRESULT*/ CreateComponentInfo(
                IntPtr pICodecFactory,
                ref Guid clsidComponent,
                out IntPtr /* IWICComponentInfo */ ppIComponentInfo);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreatePalette_Proxy")]
            internal static partial int /*HRESULT*/ CreatePalette(
                IntPtr pICodecFactory,
                out SafeMILHandle /* IWICPalette */ ppIPalette);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateFormatConverter_Proxy")]
            internal static partial int /* HRESULT */ CreateFormatConverter(
                IntPtr pICodecFactory,
                out BitmapSourceSafeMILHandle /* IWICFormatConverter */ ppFormatConverter);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateBitmapScaler_Proxy")]
            internal static partial int /* HRESULT */ CreateBitmapScaler(
                IntPtr pICodecFactory,
                out BitmapSourceSafeMILHandle /* IWICBitmapScaler */ ppBitmapScaler);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateBitmapClipper_Proxy")]
            internal static partial int /* HRESULT */ CreateBitmapClipper(
                IntPtr pICodecFactory,
                out BitmapSourceSafeMILHandle /* IWICBitmapClipper */ ppBitmapClipper);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateBitmapFlipRotator_Proxy")]
            internal static partial int /* HRESULT */ CreateBitmapFlipRotator(
                IntPtr pICodecFactory,
                out BitmapSourceSafeMILHandle /* IWICBitmapFlipRotator */ ppBitmapFlipRotator);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateStream_Proxy")]
            internal static partial int /* HRESULT */ CreateStream(
                IntPtr pICodecFactory,
                out IntPtr /* IWICBitmapStream */ ppIStream);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateEncoder_Proxy")]
            internal static partial int /* HRESULT */ CreateEncoder(
                IntPtr pICodecFactory,
                ref Guid guidContainerFormat,
                ref Guid guidVendor,
                out SafeMILHandle /* IUnknown** */ ppICodec);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateBitmapFromSource_Proxy")]
            internal static partial int /*HRESULT*/ CreateBitmapFromSource(
                IntPtr THIS_PTR,
                SafeMILHandle /* IWICBitmapSource */ pIBitmapSource,
                WICBitmapCreateCacheOptions options,
                out BitmapSourceSafeMILHandle /* IWICBitmap */ ppIBitmap);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateBitmapFromMemory_Proxy")]
            internal static partial int /*HRESULT*/ CreateBitmapFromMemory(
                IntPtr THIS_PTR,
                UInt32 width,
                UInt32 height,
                ref Guid pixelFormatGuid,
                UInt32 stride,
                UInt32 cbBufferSize,
                IntPtr /* BYTE* */ pvPixels,
                out BitmapSourceSafeMILHandle /* IWICBitmap */ ppIBitmap);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateBitmap_Proxy")]
            internal static partial int /*HRESULT*/ CreateBitmap(
                IntPtr THIS_PTR,
                UInt32 width,
                UInt32 height,
                ref Guid pixelFormatGuid,
                WICBitmapCreateCacheOptions options,
                out BitmapSourceSafeMILHandle /* IWICBitmap */ ppIBitmap);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateBitmapFromHBITMAP_Proxy")]
            internal static partial int /*HRESULT*/ CreateBitmapFromHBITMAP(
                IntPtr THIS_PTR,
                IntPtr hBitmap,
                IntPtr hPalette,
                WICBitmapAlphaChannelOption options,
                out BitmapSourceSafeMILHandle /* IWICBitmap */ ppIBitmap);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateBitmapFromHICON_Proxy")]
            internal static partial int /*HRESULT*/ CreateBitmapFromHICON(
                IntPtr THIS_PTR,
                IntPtr hIcon,
                out BitmapSourceSafeMILHandle /* IWICBitmap */ ppIBitmap);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateFastMetadataEncoderFromDecoder_Proxy")]
            internal static partial int /*HRESULT*/ CreateFastMetadataEncoderFromDecoder(
                IntPtr THIS_PTR,
                SafeMILHandle /* IWICBitmapDecoder */ pIDecoder,
                out SafeMILHandle /* IWICFastMetadataEncoder */ ppIFME);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateFastMetadataEncoderFromFrameDecode_Proxy")]
            internal static partial int /*HRESULT*/ CreateFastMetadataEncoderFromFrameDecode(
                IntPtr THIS_PTR,
                BitmapSourceSafeMILHandle /* IWICBitmapFrameDecode */ pIFrameDecode,
                out SafeMILHandle /* IWICFastMetadataEncoder */ ppIBitmap);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateQueryWriter_Proxy")]
            internal static partial int /*HRESULT*/ CreateQueryWriter(
                IntPtr THIS_PTR,
                ref Guid metadataFormat,
                ref Guid guidVendor,
                out IntPtr /* IWICMetadataQueryWriter */ queryWriter
            );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICImagingFactory_CreateQueryWriterFromReader_Proxy")]
            internal static partial int /*HRESULT*/ CreateQueryWriterFromReader(
                IntPtr THIS_PTR,
                SafeMILHandle /* IWICMetadataQueryReader */ queryReader,
                ref Guid guidVendor,
                out IntPtr /* IWICMetadataQueryWriter */ queryWriter
            );
        }

        internal static partial class WICComponentFactory
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICComponentFactory_CreateMetadataWriterFromReader_Proxy")]
            internal static partial int /*HRESULT*/ CreateMetadataWriterFromReader(
                IntPtr pICodecFactory,
                SafeMILHandle pIMetadataReader,
                ref Guid guidVendor,
                out IntPtr metadataWriter
            );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICComponentFactory_CreateQueryWriterFromBlockWriter_Proxy")]
            internal static partial int /*HRESULT*/ CreateQueryWriterFromBlockWriter(
                IntPtr pICodecFactory,
                IntPtr pIBlockWriter,
                ref IntPtr ppIQueryWriter
            );
        }

        internal static partial class WICMetadataBlockReader
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICMetadataBlockReader_GetCount_Proxy")]
            internal static partial int /*HRESULT*/ GetCount(
                IntPtr pIBlockReader,
                out UInt32 count
            );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICMetadataBlockReader_GetReaderByIndex_Proxy")]
            internal static partial int /*HRESULT*/ GetReaderByIndex(
                IntPtr pIBlockReader,
                UInt32 index,
                out SafeMILHandle /* IWICMetadataReader* */ pIMetadataReader
            );
        }

        internal static partial class WICPixelFormatInfo
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICPixelFormatInfo_GetBitsPerPixel_Proxy")]
            internal static partial int /*HRESULT*/ GetBitsPerPixel(
                IntPtr /* IWICPixelFormatInfo */ pIPixelFormatInfo,
                out UInt32 uiBitsPerPixel
            );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICPixelFormatInfo_GetChannelCount_Proxy")]
            internal static partial int /*HRESULT*/ GetChannelCount(
                IntPtr /* IWICPixelFormatInfo */ pIPixelFormatInfo,
                out UInt32 uiChannelCount
            );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICPixelFormatInfo_GetChannelMask_Proxy")]
            internal static partial unsafe int /*HRESULT*/ GetChannelMask(
                IntPtr /* IWICPixelFormatInfo */ pIPixelFormatInfo,
                UInt32 uiChannelIndex,
                UInt32 cbMaskBuffer,
                byte *pbMaskBuffer,
                out UInt32 cbActual
            );
        }

        internal static partial class WICBitmapClipper
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapClipper_Initialize_Proxy")]
            internal static partial int /* HRESULT */ Initialize(
                System.Windows.Media.SafeMILHandle /* IWICBitmapClipper */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource */ source,
                ref Int32Rect prc);
        }

        internal static partial class WICBitmapFlipRotator
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapFlipRotator_Initialize_Proxy")]
            internal static partial int /* HRESULT */ Initialize(
                System.Windows.Media.SafeMILHandle /* IWICBitmapFlipRotator */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource */ source,
                WICBitmapTransformOptions options);
        }

        internal static partial class WICBitmapScaler
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapScaler_Initialize_Proxy")]
            internal static partial int /* HRESULT */ Initialize(
                System.Windows.Media.SafeMILHandle /* IWICBitmapScaler */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource */ source,
                uint width,
                uint height,
                WICInterpolationMode mode);
        }

        internal static partial class WICFormatConverter
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICFormatConverter_Initialize_Proxy")]
            internal static partial int /* HRESULT */ Initialize(
                System.Windows.Media.SafeMILHandle /* IWICFormatConverter */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource */ source,
                ref Guid dstFormat,
                DitherType dither,
                System.Windows.Media.SafeMILHandle /* IWICBitmapPalette */ bitmapPalette,
                double alphaThreshold,
                WICPaletteType paletteTranslate
                );
        }

        internal static partial class IWICColorContext
        {
            internal enum WICColorContextType : uint 
            {
                WICColorContextUninitialized  = 0,
                WICColorContextProfile        = 1,
                WICColorContextExifColorSpace = 2
            };
            
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICColorContext_InitializeFromMemory_Proxy")]
            internal static partial int /* HRESULT */ InitializeFromMemory(
                SafeMILHandle THIS_PTR,
                byte[] pbBuffer,
                uint cbBufferSize
                );

            [LibraryImport(DllImport.MilCore, EntryPoint = "IWICColorContext_GetProfileBytes_Proxy")]
            internal static partial int /* HRESULT */ GetProfileBytes(
                SafeMILHandle THIS_PTR,
                uint cbBuffer,
                [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pbBuffer,
                out uint pcbActual
                );

            [LibraryImport(DllImport.MilCore, EntryPoint = "IWICColorContext_GetType_Proxy")]
            internal static partial int /* HRESULT */ GetType(
                SafeMILHandle THIS_PTR,
                out WICColorContextType pType
                );

            [LibraryImport(DllImport.MilCore, EntryPoint = "IWICColorContext_GetExifColorSpace_Proxy")]
            internal static partial int /* HRESULT */ GetExifColorSpace(
                SafeMILHandle THIS_PTR,
                out uint pValue
                );
        }

        internal static partial class WICColorTransform
        {
            [LibraryImport(DllImport.WindowsCodecsExt, EntryPoint = "IWICColorTransform_Initialize_Proxy")]
            internal static partial int /* HRESULT */ Initialize(
                System.Windows.Media.SafeMILHandle /* IWICColorTransform */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IWICBitmapSource */ source,
                System.Windows.Media.SafeMILHandle /* IWICColorContext */ pIContextSource,
                System.Windows.Media.SafeMILHandle /* IWICColorContext */ pIContextDest,
                ref Guid pixelFmtDest
                );
        }

        internal static partial class WICBitmap
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmap_Lock_Proxy")]
            internal static partial int /* HRESULT */ Lock(
                System.Windows.Media.SafeMILHandle /* IWICBitmap */ THIS_PTR,
                ref Int32Rect prcLock,
                LockFlags flags,
                out SafeMILHandle /* IWICBitmapLock* */ ppILock);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmap_SetResolution_Proxy")]
            internal static partial int /* HRESULT */ SetResolution(
                System.Windows.Media.SafeMILHandle /* IWICBitmap */ THIS_PTR,
                double dpiX,
                double dpiY);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmap_SetPalette_Proxy")]
            internal static partial int /* HRESULT */ SetPalette(
                System.Windows.Media.SafeMILHandle /* IWICBitmap */ THIS_PTR,
                System.Windows.Media.SafeMILHandle /* IMILPalette */ pIPalette);
        }

        internal static partial class WICBitmapLock
        {
            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapLock_GetStride_Proxy")]
            internal static partial int /* HRESULT */ GetStride(
                SafeMILHandle /* IWICBitmapLock */ pILock,
                ref uint pcbStride
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "IWICBitmapLock_GetDataPointer_STA_Proxy")]
            internal static partial int /* HRESULT */ GetDataPointer(
                SafeMILHandle /* IWICBitmapLock */ pILock,
                ref uint pcbBufferSize,
                ref IntPtr ppbData
                );
        }

        internal static partial class WICCodec
        {
            internal const int WINCODEC_SDK_VERSION = 0x0236;

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "WICCreateImagingFactory_Proxy")]
            internal static partial int CreateImagingFactory(
                UInt32 SDKVersion,
                out IntPtr ppICodecFactory
                );

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "WICConvertBitmapSource")]
            internal static partial int /* HRESULT */ WICConvertBitmapSource(
                ref Guid dstPixelFormatGuid,
                SafeMILHandle /* IWICBitmapSource */ pISrc,
                out BitmapSourceSafeMILHandle /* IWICBitmapSource* */ ppIDst);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "WICSetEncoderFormat_Proxy")]
            internal static partial int /* HRESULT */ WICSetEncoderFormat(
                SafeMILHandle /* IWICBitmapSource */ pSourceIn,
                SafeMILHandle /* IMILPalette */ pIPalette,
                SafeMILHandle /* IWICBitmapFrameEncode* */ pIFrameEncode,
                out SafeMILHandle /* IWICBitmapSource** */ ppSourceOut);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "WICMapGuidToShortName", StringMarshalling = StringMarshalling.Utf16)]
            internal static partial int /* HRESULT */ WICMapGuidToShortName(
                ref Guid guid,
                uint cchName,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte, SizeParamIndex = 1)] char[] wzName,
                ref uint pcchActual);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "WICMapShortNameToGuid", StringMarshalling = StringMarshalling.Utf16)]
            internal static partial int /* HRESULT */ WICMapShortNameToGuid(
                string wzName,
                ref Guid guid);

            [LibraryImport(DllImport.WindowsCodecsExt, EntryPoint = "WICCreateColorTransform_Proxy")]
            internal static partial int /* HRESULT */ CreateColorTransform(
                out BitmapSourceSafeMILHandle  /* IWICColorTransform */ ppWICColorTransform);

            [LibraryImport(DllImport.WindowsCodecs, EntryPoint = "WICCreateColorContext_Proxy")]
            internal static partial int /* HRESULT */ CreateColorContext(
                IntPtr pICodecFactory,
                out System.Windows.Media.SafeMILHandle /* IWICColorContext */ ppColorContext);

            [LibraryImport("ole32.dll")]
            internal static partial int /* HRESULT */ CoInitialize(
                    IntPtr reserved);

            [LibraryImport("ole32.dll")]
            internal static partial void CoUninitialize();
        }

        internal static partial class Mscms
        {
            [LibraryImport(DllImport.Mscms, EntryPoint = "CreateMultiProfileTransform")]
            internal static partial ColorTransformHandle /* HTRANSFORM */ CreateMultiProfileTransform(
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IntPtr[] /* PHPROFILE */ pahProfiles, 
                UInt32 nProfiles, 
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] UInt32[] padwIntent, 
                UInt32 nIntents, 
                UInt32 dwFlags, 
                UInt32 indexPreferredCMM);

            [LibraryImport(DllImport.Mscms, EntryPoint = "DeleteColorTransform", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static partial bool DeleteColorTransform(IntPtr /* HTRANSFORM */ hColorTransform);

            [LibraryImport(DllImport.Mscms, EntryPoint = "TranslateColors")]
            internal static partial int /* HRESULT */ TranslateColors(ColorTransformHandle /* HTRANSFORM */ hColorTransform, IntPtr paInputColors, UInt32 nColors, UInt32 ctInput, IntPtr paOutputColors, UInt32 ctOutput);

            [LibraryImport(DllImport.Mscms, EntryPoint = "OpenColorProfile")]
            internal static partial SafeProfileHandle /* HANDLE */ OpenColorProfile(ref MS.Win32.UnsafeNativeMethods.PROFILE pProfile, UInt32 dwDesiredAccess, UInt32 dwShareMode, UInt32 dwCreationMode);

            [LibraryImport(DllImport.Mscms, EntryPoint = "CloseColorProfile", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static partial bool CloseColorProfile(IntPtr /* HANDLE */ phProfile);

            [LibraryImport(DllImport.Mscms, EntryPoint = "GetColorProfileHeader", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static partial bool GetColorProfileHeader(SafeProfileHandle /* HANDLE */ phProfile, out MS.Win32.UnsafeNativeMethods.PROFILEHEADER pHeader);

            [LibraryImport(DllImport.Mscms, StringMarshalling = StringMarshalling.Utf16, SetLastError = false)]
            internal static partial int /* HRESULT */ GetColorDirectory(
                IntPtr pMachineName, 
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte)] char[] pBuffer, 
                out uint pdwSize);

            [LibraryImport(DllImport.Mscms, StringMarshalling = StringMarshalling.Utf16, SetLastError = false)]
            internal static partial int /* HRESULT */ GetStandardColorSpaceProfile(
                IntPtr pMachineName, 
                uint dwProfileID, 
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.TwoByte)] char[] pProfileName, 
                out uint pdwSize);

            [LibraryImport(DllImport.Mscms, EntryPoint = "GetColorProfileFromHandle", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static partial bool GetColorProfileFromHandle(SafeProfileHandle /* HANDLE */ hProfile, byte[] pBuffer, ref uint pdwSize);
        }

        internal static partial class MILFactory2
        {
            [LibraryImport(DllImport.MilCore, EntryPoint = "MILCreateFactory")]
            internal static partial int CreateFactory(
                out IntPtr ppIFactory,
                UInt32 SDKVersion
                );

            [LibraryImport(DllImport.MilCore, EntryPoint = "MILFactoryCreateMediaPlayer")]
            internal static partial int /*HRESULT*/ CreateMediaPlayer(
                IntPtr THIS_PTR,
                SafeMILHandle /* CEventProxy */ pEventProxy,
                [MarshalAs(UnmanagedType.Bool)] bool canOpenAllMedia,
                out SafeMediaHandle /* IMILMedia */ ppMedia);

            [LibraryImport(DllImport.MilCore, EntryPoint = "MILFactoryCreateBitmapRenderTarget")]
            internal static partial int /* HRESULT */ CreateBitmapRenderTarget(
                IntPtr THIS_PTR,
                UInt32 width,
                UInt32 height,
                PixelFormatEnum pixelFormatEnum,
                float dpiX,
                float dpiY,
                MILRTInitializationFlags dwFlags,
                out SafeMILHandle /* IMILRenderTargetBitmap */ ppIRenderTargetBitmap);

            [LibraryImport(DllImport.MilCore, EntryPoint = "MILFactoryCreateSWRenderTargetForBitmap")]
            internal static partial int /* HRESULT */ CreateBitmapRenderTargetForBitmap(
                IntPtr THIS_PTR,
                BitmapSourceSafeMILHandle /* IWICBitmap */ pIBitmap,
                out SafeMILHandle /* IMILRenderTargetBitmap */ ppIRenderTargetBitmap);
        }

        internal static partial class InteropDeviceBitmap
        {
            internal delegate void FrontBufferAvailableCallback([MarshalAs(UnmanagedType.Bool)] bool lost, uint version);
            
            [LibraryImport(DllImport.MilCore, EntryPoint = "InteropDeviceBitmap_Create")]
            internal static partial int Create(
                IntPtr d3dResource,
                double dpiX,
                double dpiY,
                uint version,
                FrontBufferAvailableCallback pfnCallback,
                [MarshalAs(UnmanagedType.Bool)] bool isSoftwareFallbackEnabled,
                out SafeMILHandle ppInteropDeviceBitmap,
                out uint pixelWidth,
                out uint pixelHeight
                );

            [LibraryImport(DllImport.MilCore, EntryPoint = "InteropDeviceBitmap_Detach")]
            internal static partial void Detach(
                SafeMILHandle pInteropDeviceBitmap
                );

            [LibraryImport(DllImport.MilCore, EntryPoint = "InteropDeviceBitmap_AddDirtyRect")]
            internal static partial int AddDirtyRect(
                int x, 
                int y, 
                int w, 
                int h,
                SafeMILHandle pInteropDeviceBitmap
                );

            [LibraryImport(DllImport.MilCore, EntryPoint = "InteropDeviceBitmap_GetAsSoftwareBitmap")]
            internal static partial int GetAsSoftwareBitmap(SafeMILHandle pInteropDeviceBitmap, out BitmapSourceSafeMILHandle pIWICBitmapSource);
        }
    }
}

