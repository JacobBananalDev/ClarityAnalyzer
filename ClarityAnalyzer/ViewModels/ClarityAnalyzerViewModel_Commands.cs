using ClarityAnalyzer.Commands;
using ClarityAnalyzer.Helpers;
using ClarityAnalyzer.Models;
using ClarityAnalyzer.Services;
using System.Drawing;
using System.Windows;

namespace ClarityAnalyzer.ViewModels
{
    public partial class ClarityAnalyzerViewModel
    {
        private RelayCommand m_LoadImageCommand = null;
        public RelayCommand LoadImageCommand
        {
            get
            {
                if (m_LoadImageCommand == null)
                {
                    m_LoadImageCommand = new RelayCommand((obj) =>
                    {
                        Bitmap loadedBitmap = FileService.LoadImageFromDialog();

                        if (loadedBitmap != null)
                        {
                            m_OriginalBitmap = (Bitmap)loadedBitmap.Clone();
                            m_CurrentBitmap = loadedBitmap;
                            ImageViewer = ImageHelper.ToBitMapImage(m_CurrentBitmap);
                        }
                    });
                }
                return m_LoadImageCommand;
            }
        }

        private RelayCommand m_SaveImageCommand = null;
        public RelayCommand SaveImageCommand
        {
            get
            {
                if (m_SaveImageCommand == null)
                {
                    m_SaveImageCommand = new RelayCommand((obj) =>
                    {
                        if (m_CurrentBitmap != null)
                        {
                            FileService.SaveImageToDialog(m_CurrentBitmap);
                        }
                        else
                        {
                            // TODO: Add status or error message here that will display on the UI
                        }
                    });
                }
                return m_SaveImageCommand;
            }
        }

        private RelayCommand m_ResetImageCommand = null;
        public RelayCommand ResetImageCommand
        {
            get
            {
                if (m_ResetImageCommand == null)
                {
                    m_ResetImageCommand = new RelayCommand((obj) =>
                    {
                        if (m_OriginalBitmap == null)
                        {
                            //MessageBox.Show("No original image loaded.");
                            return;
                        }

                        m_CurrentBitmap = (Bitmap)m_OriginalBitmap.Clone();
                        ImageViewer = ImageHelper.ToBitMapImage(m_CurrentBitmap);
                    });
                }
                return m_ResetImageCommand;
            }
        }

        private RelayCommand m_ApplyFiltersCommand = null;
        public RelayCommand ApplyFiltersCommand
        {
            get
            {
                if (m_ApplyFiltersCommand == null)
                {
                    m_ApplyFiltersCommand = new RelayCommand((obj) =>
                    {
                        if (m_CurrentBitmap == null)
                        {
                            // TODO: Add status or error message here that will display on the UI
                            return;
                        }

                        if (string.IsNullOrEmpty(SelectedFilter))
                        {
                            // TODO: Add status or error message here that will display on the UI
                            return;
                        }

                        switch (SelectedFilter)
                        {
                            case "Sharpen":
                                m_CurrentBitmap = ImageProcessor.Instance.ApplySharpen(m_CurrentBitmap);
                                break;
                            case "Box Blur":
                                m_CurrentBitmap = ImageProcessor.Instance.ApplyBoxBlur(m_CurrentBitmap);
                                break;
                            case "Gaussian Blur":
                                m_CurrentBitmap = ImageProcessor.Instance.ApplyGaussianBlur(m_CurrentBitmap);
                                break;
                            case "Edge Detect - Horizontal":
                                m_CurrentBitmap = ImageProcessor.Instance.ApplyEdgeDetectHorizontal(m_CurrentBitmap);
                                break;
                            case "Edge Detect - Vertical":
                                m_CurrentBitmap = ImageProcessor.Instance.ApplyEdgeDetectVertical(m_CurrentBitmap);
                                break;
                            default:
                                // TODO: Add status or error message here that will display on the UI
                                break;
                        }

                        ImageViewer = ImageHelper.ToBitMapImage(m_CurrentBitmap);
                    });
                }
                return m_ApplyFiltersCommand;
            }
        }
    }
}
