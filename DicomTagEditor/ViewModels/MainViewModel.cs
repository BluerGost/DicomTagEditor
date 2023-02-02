using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomTagEditor.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Constructors

        public MainViewModel()
        {

        }

        #endregion

        #region Properties

        //public ObservableCollection<TagList> DicomTagList { get; set; }

        #endregion

        #region Commands

        // Opens file from the local drive and displays its tags to the UI
        public RelayCommand  CommandOpenDicomFile
        {
            get
            {
                return new RelayCommand(
                    delegate (object aObj)
                    {
                        try
                        {
                            // Select a file from the local drive

                            // Open the file using dicom parser

                            // Extract the tags and add it to the DicomTagList
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {

                        }
                    });
            }
        }

        // Updates the Dicomfile with the new tag values.
        public RelayCommand CommandSaveChanges
        {
            get
            {
                return new RelayCommand(
                    delegate (object aObj)
                    {
                        try
                        {
                            // Get the updated values from the datagrid
                            // Update the dicom file with the new value 
                            // Save the file in the local drive.(could ask the user for location or save it in the original locaiton)
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {

                        }
                    });
            }
        }



        #endregion
    }
}
