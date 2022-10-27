using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.IO;

namespace RevitMenu_GYGC
{
    [Transaction(TransactionMode.Manual)]
    public class IMyApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("轻量化");
            RibbonPanel ML_ribbonPanel = application.CreateRibbonPanel("轻量化","公用工程");
            PushButtonData ML_pushButtonData = new PushButtonData("ML","模型轻量化",Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\RevitMLightening\\RevitMLightening.dll", 
                "RevitMLightening.MyICommand");
            PushButton ML_pushButton = ML_ribbonPanel.AddItem(ML_pushButtonData) as PushButton;
            Bitmap bitmap = Properties.Resources.house_36;
            ML_pushButton.LargeImage = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), 
                IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return Result.Succeeded;
        }
    }
}
