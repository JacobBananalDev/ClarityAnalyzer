using ClarityAnalyzer.Commands;
using ClarityAnalyzer.Services;
using System.Drawing;

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
                        // Save image logic here
                        // For example, open a save file dialog and save the current image
                    });
                }
                return m_SaveImageCommand;
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
                        // Apply filters logic here
                        // For example, apply selected filters to the image
                    });
                }
                return m_ApplyFiltersCommand;
            }
        }
    }
}
