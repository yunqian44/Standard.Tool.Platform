using MediatR;
using Standard.Tool.Platform.Data.Exporting;
using Standard.Tool.Platform.Data.Infrastructure;
using Standard.Tool.Platform.Materials;
using Standard.Tool.Platform.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Standard.Tool.Platform.Common.Extension;
using MaterialCore = Standard.Tool.Platform.Materials;
using System.Threading.Tasks;
using Standard.Tool.Platform.Auth.AccountFeature;

namespace Standard.Tool.Platform.Pages.Project.Application.Material
{
    public class MaterialDataOperatePageViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private readonly IReadTableService _readTableService;

        public MaterialDataOperatePageViewModel(IMediator mediator, IReadTableService readTableService)
        {
            _mediator = mediator;
            _readTableService = readTableService;
        }

        #region Property

        #region MaterialDataTable
        private ObservableCollection<MaterialCore.Material> _materialDataTable;

        public ObservableCollection<MaterialCore.Material> MaterialDataTable
        {
            get { return _materialDataTable; }
            set
            {
                _materialDataTable = value;
                RaisePropertyChanged(nameof(MaterialDataTable));
            }
        }
        #endregion

        #endregion


        #region Method

        #region 01，Export
        void ExportExecute()
        {
            Task.Run(async
            () =>
            {
                var exportResult = await _mediator.Send(new ExportMaterialDataCommand());
            });
        }

        bool CanExportExecute()
        {
            return true;
        }

        public ICommand Export
        {
            get { return new RelayCommand(ExportExecute, CanExportExecute); }
        }
        #endregion 

        #region 02，Import
        void ImportExecute()
        {
            var materiallist = _readTableService.ReadExcel().DataSetToList<MaterialCore.Material>();
            MaterialDataTable = new ObservableCollection<MaterialCore.Material>(materiallist);
        }

        bool CanImportExecute()
        {
            return true;
        }

        public ICommand Import
        {
            get { return new RelayCommand(ImportExecute, CanImportExecute); }
        }
        #endregion 

        #region 03，Save
        void SaveExecute()
        {
            var request = new EditMaterialRequest(MaterialDataTable);
            if (request.IsValid())
            {
                Task.Run(async () =>
                {
                    var exportResult = await _mediator.Send(new CreateMaterialDataCommand(request));
                });
            }
        }

        bool CanSaveExecute()
        {
            return true;
        }

        public ICommand Save
        {
            get { return new RelayCommand(SaveExecute, CanSaveExecute); }
        }
        #endregion 

        #endregion

    }
}
