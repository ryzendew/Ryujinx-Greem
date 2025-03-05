using Avalonia.Svg.Skia;
using CommunityToolkit.Mvvm.ComponentModel;
using Ryujinx.Ava.UI.Models.Input;

namespace Ryujinx.Ava.UI.ViewModels.Input
{
    public partial class KeyboardInputViewModel : BaseModel
    {
        private KeyboardInputConfig _config;
        public KeyboardInputConfig Config
        {
            get => _config;
            set
            {
                _config = value;

                OnPropertyChanged();
            }
        }

        private StickVisualizer _visualizer;
        public StickVisualizer Visualizer
        {
            get => _visualizer;
            set
            {
                _visualizer = value;

                OnPropertyChanged();
            }
        }

        private bool _isLeft;
        public bool IsLeft
        {
            get => _isLeft;
            set
            {
                _isLeft = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasSides));
            }
        }

        private bool _isRight;
        public bool IsRight
        {
            get => _isRight;
            set
            {
                _isRight = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasSides));
            }
        }

        public bool HasSides => IsLeft ^ IsRight;

        [ObservableProperty] private SvgImage _image;

        public readonly InputViewModel ParentModel;

        public KeyboardInputViewModel(InputViewModel model, KeyboardInputConfig config, StickVisualizer visualizer)
        {
            ParentModel = model;
            Visualizer = visualizer;
            model.NotifyChangesEvent += OnParentModelChanged;
            OnParentModelChanged();
            Config = config;
        }

        public void OnParentModelChanged()
        {
            IsLeft = ParentModel.IsLeft;
            IsRight = ParentModel.IsRight;
            Image = ParentModel.Image;
        }
    }
}
