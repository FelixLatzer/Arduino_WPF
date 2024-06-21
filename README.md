<p align="center">
  <img src="https://cdn-icons-png.flaticon.com/512/6295/6295417.png" width="100" />
</p>
<p align="center">
    <h1 align="center"></h1>
</p>
<p align="center">
    <em>Arduino_WPF</em>
</p>
<p align="center">
	<img src="https://img.shields.io/github/license/FelixLatzer/Arduino_WPF?style=flat&color=0080ff" alt="license">
	<img src="https://img.shields.io/github/last-commit/FelixLatzer/Arduino_WPF?style=flat&logo=git&logoColor=white&color=0080ff" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/FelixLatzer/Arduino_WPF?style=flat&color=0080ff" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/FelixLatzer/Arduino_WPF?style=flat&color=0080ff" alt="repo-language-count">
<p>
<p align="center">
		<em>Developed with the software and tools below.</em>
</p>
<p align="center">
	<img src="https://img.shields.io/badge/EditorConfig-FEFEFE.svg?style=flat&logo=EditorConfig&logoColor=black" alt="EditorConfig">
	<img src="https://img.shields.io/badge/XAML-0C54C2.svg?style=flat&logo=XAML&logoColor=white" alt="XAML">
	<img src="https://img.shields.io/badge/JSON-000000.svg?style=flat&logo=JSON&logoColor=white" alt="JSON">
</p>
<hr>

##  Quick Links

> - [ Overview](#-overview)
> - [ Features](#-features)
> - [ Repository Structure](#-repository-structure)
> - [ Modules](#-modules)
> - [ Getting Started](#-getting-started)
>   - [ Installation](#-installation)
>   - [ Running ](#-running-)
>   - [ Tests](#-tests)
> - [ Project Roadmap](#-project-roadmap)
> - [ Contributing](#-contributing)
> - [ License](#-license)
> - [ Acknowledgments](#-acknowledgments)

---

##  Overview

HTTP error 429 for prompt `overview`

---

##  Features

HTTP error 429 for prompt `features`

---

##  Repository Structure

```sh
└── /
    ├── Arduino_WPF
    │   ├── .editorconfig
    │   ├── Arduino_WPF
    │   │   ├── .editorconfig
    │   │   ├── App.xaml
    │   │   ├── App.xaml.cs
    │   │   ├── Arduino_WPF.csproj
    │   │   ├── AssemblyInfo.cs
    │   │   ├── Images
    │   │   │   └── GPIO_LAYOUT_ARDUINO_UNO.png
    │   │   ├── McuConfigs
    │   │   │   ├── LED_OFF.json
    │   │   │   ├── LED_ON.json
    │   │   │   ├── config_1.json
    │   │   │   ├── config_2.json
    │   │   │   └── config_4.json
    │   │   ├── Models
    │   │   │   ├── COM.cs
    │   │   │   ├── Pin.cs
    │   │   │   └── PinMode.cs
    │   │   ├── Utils
    │   │   │   ├── PresetJsonLoader.cs
    │   │   │   ├── RelayCommand.cs
    │   │   │   ├── RelayCommandWithParameter.cs
    │   │   │   └── StringToVisibilityConverter.cs
    │   │   ├── ViewModels
    │   │   │   ├── BaseViewModel.cs
    │   │   │   ├── CustomPinViewModel.cs
    │   │   │   ├── MainWindowViewModel.cs
    │   │   │   ├── PinViewViewModel.cs
    │   │   │   ├── SerialConnectionViewViewModel.cs
    │   │   │   └── SerialMonitorViewModel.cs
    │   │   └── Views
    │   │       ├── CustomPin.xaml
    │   │       ├── CustomPin.xaml.cs
    │   │       ├── MainWindow.xaml
    │   │       ├── MainWindow.xaml.cs
    │   │       ├── PinView.xaml
    │   │       ├── PinView.xaml.cs
    │   │       ├── SerialConnectionView.xaml
    │   │       ├── SerialConnectionView.xaml.cs
    │   │       ├── SerialMonitorWindow.xaml
    │   │       └── SerialMonitorWindow.xaml.cs
    │   └── Arduino_WPF.sln
    ├── LICENSE
    ├── docs
    │   ├── Control a Microcrontroller over WPF.docx
    │   ├── Control a Microcrontroller over WPF.pdf
    │   ├── Demos
    │   │   └── Demo_1.mp4
    │   ├── Doxyfile
    │   ├── Doxygen
    │   │   ├── html
    │   │   │   ├── annotated.html
    │   │   │   ├── bc_s.png
    │   │   │   ├── bc_sd.png
    │   │   │   ├── class_arduino___w_p_f_1_1_app-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_app.html
    │   │   │   ├── class_arduino___w_p_f_1_1_app.png
    │   │   │   ├── class_arduino___w_p_f_1_1_main_window-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_main_window.html
    │   │   │   ├── class_arduino___w_p_f_1_1_main_window.png
    │   │   │   ├── class_arduino___w_p_f_1_1_models_1_1_c_o_m-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_models_1_1_c_o_m.html
    │   │   │   ├── class_arduino___w_p_f_1_1_models_1_1_pin-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_models_1_1_pin.html
    │   │   │   ├── class_arduino___w_p_f_1_1_utils_1_1_preset_json_loader-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_utils_1_1_preset_json_loader.html
    │   │   │   ├── class_arduino___w_p_f_1_1_utils_1_1_string_to_visibility_converter-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_utils_1_1_string_to_visibility_converter.html
    │   │   │   ├── class_arduino___w_p_f_1_1_utils_1_1_string_to_visibility_converter.png
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_base_view_model-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_base_view_model.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_base_view_model.png
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_custom_pin_view_model-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_custom_pin_view_model.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_custom_pin_view_model.png
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_main_window_view_model-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_main_window_view_model.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_main_window_view_model.png
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_pin_view_view_model-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_pin_view_view_model.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_pin_view_view_model.png
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_connection_view_view_model-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_connection_view_view_model.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_connection_view_view_model.png
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_monitor_view_model-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_monitor_view_model.html
    │   │   │   ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_monitor_view_model.png
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_custom_pin-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_custom_pin.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_custom_pin.png
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_main_view-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_main_view.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_main_view.png
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_custom_pin-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_custom_pin.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_custom_pin.png
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_main_window-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_main_window.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_main_window.png
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_pin_view-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_pin_view.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_pin_view.png
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view.png
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view__1-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view__1.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view__1.png
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_window-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_window.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_window.png
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_winodw-members.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_winodw.html
    │   │   │   ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_winodw.png
    │   │   │   ├── class_xaml_generated_namespace_1_1_generated_internal_type_helper-members.html
    │   │   │   ├── class_xaml_generated_namespace_1_1_generated_internal_type_helper.html
    │   │   │   ├── class_xaml_generated_namespace_1_1_generated_internal_type_helper.png
    │   │   │   ├── classes.html
    │   │   │   ├── closed.png
    │   │   │   ├── dir_14a5f638ac9b2e7c48014b8af382d620.html
    │   │   │   ├── dir_158fcd94e5f21d7e7ff05fdf4d77fa1b.html
    │   │   │   ├── dir_26b1dbbed7d13fc1276a1fc3fbe9a129.html
    │   │   │   ├── dir_2ddbb956406c0c3ba631e624e74a3857.html
    │   │   │   ├── dir_42d07fcb83f7e4acccfaa875e89f2c1f.html
    │   │   │   ├── dir_5fd91aa52b7092c8ffb51eb98e72142f.html
    │   │   │   ├── dir_61277848a07b1a7069a936e7cd0d31fa.html
    │   │   │   ├── dir_747ada84f41b2de08c332489a74ebf67.html
    │   │   │   ├── dir_80391abaa486b4df17eb0642172595c3.html
    │   │   │   ├── dir_9b2605f9633d8069bc899de5e672453e.html
    │   │   │   ├── dir_a705e8810409478d752359aa583e3e00.html
    │   │   │   ├── dir_b65b5412f197ac19e019f0cef4db90a4.html
    │   │   │   ├── dir_be384d8615328cea75e0e97c8dfbb322.html
    │   │   │   ├── dir_cac65be00e2794f7d41873dbdfcea92a.html
    │   │   │   ├── doc.svg
    │   │   │   ├── docd.svg
    │   │   │   ├── doxygen.css
    │   │   │   ├── doxygen.svg
    │   │   │   ├── dynsections.js
    │   │   │   ├── folderclosed.svg
    │   │   │   ├── folderclosedd.svg
    │   │   │   ├── folderopen.svg
    │   │   │   ├── folderopend.svg
    │   │   │   ├── functions.html
    │   │   │   ├── functions_func.html
    │   │   │   ├── functions_prop.html
    │   │   │   ├── hierarchy.html
    │   │   │   ├── index.html
    │   │   │   ├── jquery.js
    │   │   │   ├── menu.js
    │   │   │   ├── menudata.js
    │   │   │   ├── minus.svg
    │   │   │   ├── minusd.svg
    │   │   │   ├── namespace_arduino___w_p_f.html
    │   │   │   ├── namespace_arduino___w_p_f_1_1_models.html
    │   │   │   ├── namespace_arduino___w_p_f_1_1_utils.html
    │   │   │   ├── namespace_arduino___w_p_f_1_1_view_models.html
    │   │   │   ├── namespace_arduino___w_p_f_1_1_views.html
    │   │   │   ├── namespace_arduino___w_p_f_1_1_views_1_1_custom_controlls.html
    │   │   │   ├── namespace_xaml_generated_namespace.html
    │   │   │   ├── namespacemembers.html
    │   │   │   ├── namespacemembers_enum.html
    │   │   │   ├── namespaces.html
    │   │   │   ├── nav_f.png
    │   │   │   ├── nav_fd.png
    │   │   │   ├── nav_g.png
    │   │   │   ├── nav_h.png
    │   │   │   ├── nav_hd.png
    │   │   │   ├── open.png
    │   │   │   ├── plus.svg
    │   │   │   ├── plusd.svg
    │   │   │   ├── search
    │   │   │   │   ├── all_0.js
    │   │   │   │   ├── all_1.js
    │   │   │   │   ├── all_2.js
    │   │   │   │   ├── all_3.js
    │   │   │   │   ├── all_4.js
    │   │   │   │   ├── all_5.js
    │   │   │   │   ├── all_6.js
    │   │   │   │   ├── all_7.js
    │   │   │   │   ├── all_8.js
    │   │   │   │   ├── all_9.js
    │   │   │   │   ├── all_a.js
    │   │   │   │   ├── all_b.js
    │   │   │   │   ├── all_c.js
    │   │   │   │   ├── all_d.js
    │   │   │   │   ├── all_e.js
    │   │   │   │   ├── all_f.js
    │   │   │   │   ├── classes_0.js
    │   │   │   │   ├── classes_1.js
    │   │   │   │   ├── classes_2.js
    │   │   │   │   ├── classes_3.js
    │   │   │   │   ├── classes_4.js
    │   │   │   │   ├── classes_5.js
    │   │   │   │   ├── classes_6.js
    │   │   │   │   ├── close.svg
    │   │   │   │   ├── enums_0.js
    │   │   │   │   ├── enums_1.js
    │   │   │   │   ├── functions_0.js
    │   │   │   │   ├── functions_1.js
    │   │   │   │   ├── functions_2.js
    │   │   │   │   ├── functions_3.js
    │   │   │   │   ├── functions_4.js
    │   │   │   │   ├── functions_5.js
    │   │   │   │   ├── functions_6.js
    │   │   │   │   ├── functions_7.js
    │   │   │   │   ├── functions_8.js
    │   │   │   │   ├── functions_9.js
    │   │   │   │   ├── functions_a.js
    │   │   │   │   ├── functions_b.js
    │   │   │   │   ├── functions_c.js
    │   │   │   │   ├── mag.svg
    │   │   │   │   ├── mag_d.svg
    │   │   │   │   ├── mag_sel.svg
    │   │   │   │   ├── mag_seld.svg
    │   │   │   │   ├── namespaces_0.js
    │   │   │   │   ├── namespaces_1.js
    │   │   │   │   ├── properties_0.js
    │   │   │   │   ├── properties_1.js
    │   │   │   │   ├── properties_2.js
    │   │   │   │   ├── properties_3.js
    │   │   │   │   ├── properties_4.js
    │   │   │   │   ├── properties_5.js
    │   │   │   │   ├── properties_6.js
    │   │   │   │   ├── search.css
    │   │   │   │   ├── search.js
    │   │   │   │   └── searchdata.js
    │   │   │   ├── splitbar.png
    │   │   │   ├── splitbard.png
    │   │   │   ├── sync_off.png
    │   │   │   ├── sync_on.png
    │   │   │   ├── tab_a.png
    │   │   │   ├── tab_ad.png
    │   │   │   ├── tab_b.png
    │   │   │   ├── tab_bd.png
    │   │   │   ├── tab_h.png
    │   │   │   ├── tab_hd.png
    │   │   │   ├── tab_s.png
    │   │   │   ├── tab_sd.png
    │   │   │   └── tabs.css
    │   │   └── latex
    │   │       ├── Makefile
    │   │       ├── annotated.tex
    │   │       ├── class_arduino___w_p_f_1_1_app-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_app.eps
    │   │       ├── class_arduino___w_p_f_1_1_app.pdf
    │   │       ├── class_arduino___w_p_f_1_1_app.tex
    │   │       ├── class_arduino___w_p_f_1_1_main_window.eps
    │   │       ├── class_arduino___w_p_f_1_1_main_window.tex
    │   │       ├── class_arduino___w_p_f_1_1_models_1_1_c_o_m.tex
    │   │       ├── class_arduino___w_p_f_1_1_models_1_1_pin.tex
    │   │       ├── class_arduino___w_p_f_1_1_utils_1_1_preset_json_loader.tex
    │   │       ├── class_arduino___w_p_f_1_1_utils_1_1_string_to_visibility_converter-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_utils_1_1_string_to_visibility_converter.eps
    │   │       ├── class_arduino___w_p_f_1_1_utils_1_1_string_to_visibility_converter.pdf
    │   │       ├── class_arduino___w_p_f_1_1_utils_1_1_string_to_visibility_converter.tex
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_base_view_model-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_base_view_model.eps
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_base_view_model.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_base_view_model.tex
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_custom_pin_view_model-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_custom_pin_view_model.eps
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_custom_pin_view_model.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_custom_pin_view_model.tex
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_main_window_view_model-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_main_window_view_model.eps
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_main_window_view_model.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_main_window_view_model.tex
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_pin_view_view_model-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_pin_view_view_model.eps
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_pin_view_view_model.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_pin_view_view_model.tex
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_connection_view_view_model-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_connection_view_view_model.eps
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_connection_view_view_model.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_connection_view_view_model.tex
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_monitor_view_model.eps
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_monitor_view_model.pdf
    │   │       ├── class_arduino___w_p_f_1_1_view_models_1_1_serial_monitor_view_model.tex
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_custom_pin-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_custom_pin.eps
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_custom_pin.tex
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_main_view-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_main_view.eps
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_custom_controlls_1_1_main_view.tex
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_custom_pin.eps
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_custom_pin.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_custom_pin.tex
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_main_window-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_main_window.eps
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_main_window.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_main_window.tex
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_pin_view.eps
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_pin_view.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_pin_view.tex
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view.eps
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view.tex
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view__1-eps-converted-to.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view__1.eps
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_connection_view__1.tex
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_window.eps
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_window.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_window.tex
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_winodw.eps
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_winodw.pdf
    │   │       ├── class_arduino___w_p_f_1_1_views_1_1_serial_monitor_winodw.tex
    │   │       ├── class_xaml_generated_namespace_1_1_generated_internal_type_helper-eps-converted-to.pdf
    │   │       ├── class_xaml_generated_namespace_1_1_generated_internal_type_helper.eps
    │   │       ├── class_xaml_generated_namespace_1_1_generated_internal_type_helper.pdf
    │   │       ├── class_xaml_generated_namespace_1_1_generated_internal_type_helper.tex
    │   │       ├── doxygen.sty
    │   │       ├── etoc_doxygen.sty
    │   │       ├── hierarchy.tex
    │   │       ├── longtable_doxygen.sty
    │   │       ├── make.bat
    │   │       ├── namespace_arduino___w_p_f.tex
    │   │       ├── namespace_arduino___w_p_f_1_1_models.tex
    │   │       ├── namespace_arduino___w_p_f_1_1_utils.tex
    │   │       ├── namespace_arduino___w_p_f_1_1_view_models.tex
    │   │       ├── namespace_arduino___w_p_f_1_1_views.tex
    │   │       ├── namespace_arduino___w_p_f_1_1_views_1_1_custom_controlls.tex
    │   │       ├── namespace_xaml_generated_namespace.tex
    │   │       ├── namespaces.tex
    │   │       ├── refman.aux
    │   │       ├── refman.idx
    │   │       ├── refman.ilg
    │   │       ├── refman.ind
    │   │       ├── refman.out
    │   │       ├── refman.pdf
    │   │       ├── refman.tex
    │   │       ├── refman.toc
    │   │       └── tabu_doxygen.sty
    │   ├── UML
    │   │   ├── V0.drawio
    │   │   └── V1.drawio
    │   ├── UsefulLinksArduinoNET.txt
    │   └── refman.pdf
    ├── external
    │   ├── COM
    │   │   ├── ArduinoTestSerialOutput
    │   │   │   └── ArduinoTestSerialOutput.ino
    │   │   ├── COMTests
    │   │   │   └── COMTests.ino
    │   │   └── MoreSerialSettingsTest
    │   │       └── MoreSerialSettingsTest.ino
    │   ├── ExtendedSimpleTransmitReceivce
    │   │   └── ExtendedSimpleTransmitReceivce.ino
    │   ├── JsonArduino
    │   │   └── JsonArduino.ino
    │   └── SimpleReceiveData
    │       └── SimpleReceiveData.ino
    └── project
        ├── AufbauGui.pdf
        ├── Deadline.txt
        ├── FSST_5BELI_Projektanforderungen.md
        ├── FSST_5BELI_Projektanforderungen.pdf
        └── GPIO
            └── GPIO_LAYOUT_ARDUINO_UNO.png
```

---

##  Modules

<details closed><summary>project</summary>

| File                                                                                        | Summary                                          |
| ---                                                                                         | ---                                              |
| [Deadline.txt](https://github.com/FelixLatzer/Arduino_WPF/blob/master/project/Deadline.txt) | HTTP error 429 for prompt `project/Deadline.txt` |

</details>

<details closed><summary>docs.Doxygen.latex</summary>

| File                                                                                           | Summary                                                 |
| ---                                                                                            | ---                                                     |
| [Makefile](https://github.com/FelixLatzer/Arduino_WPF/blob/master/docs/Doxygen/latex/Makefile) | HTTP error 429 for prompt `docs/Doxygen/latex/Makefile` |

</details>

<details closed><summary>Arduino_WPF</summary>

| File                                                                                                  | Summary                                                 |
| ---                                                                                                   | ---                                                     |
| [.editorconfig](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/.editorconfig)     | HTTP error 429 for prompt `Arduino_WPF/.editorconfig`   |
| [Arduino_WPF.sln](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF.sln) | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF.sln` |

</details>

<details closed><summary>Arduino_WPF.Arduino_WPF</summary>

| File                                                                                                                    | Summary                                                                |
| ---                                                                                                                     | ---                                                                    |
| [AssemblyInfo.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/AssemblyInfo.cs)       | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/AssemblyInfo.cs`    |
| [App.xaml.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/App.xaml.cs)               | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/App.xaml.cs`        |
| [.editorconfig](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/.editorconfig)           | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/.editorconfig`      |
| [App.xaml](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/App.xaml)                     | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/App.xaml`           |
| [Arduino_WPF.csproj](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Arduino_WPF.csproj) | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Arduino_WPF.csproj` |

</details>

<details closed><summary>Arduino_WPF.Arduino_WPF.McuConfigs</summary>

| File                                                                                                                     | Summary                                                                      |
| ---                                                                                                                      | ---                                                                          |
| [config_2.json](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/McuConfigs/config_2.json) | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/McuConfigs/config_2.json` |
| [LED_OFF.json](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/McuConfigs/LED_OFF.json)   | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/McuConfigs/LED_OFF.json`  |
| [LED_ON.json](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/McuConfigs/LED_ON.json)     | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/McuConfigs/LED_ON.json`   |
| [config_4.json](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/McuConfigs/config_4.json) | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/McuConfigs/config_4.json` |
| [config_1.json](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/McuConfigs/config_1.json) | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/McuConfigs/config_1.json` |

</details>

<details closed><summary>Arduino_WPF.Arduino_WPF.ViewModels</summary>

| File                                                                                                                                                           | Summary                                                                                         |
| ---                                                                                                                                                            | ---                                                                                             |
| [MainWindowViewModel.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/ViewModels/MainWindowViewModel.cs)                     | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/ViewModels/MainWindowViewModel.cs`           |
| [SerialConnectionViewViewModel.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/ViewModels/SerialConnectionViewViewModel.cs) | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/ViewModels/SerialConnectionViewViewModel.cs` |
| [SerialMonitorViewModel.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/ViewModels/SerialMonitorViewModel.cs)               | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/ViewModels/SerialMonitorViewModel.cs`        |
| [CustomPinViewModel.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/ViewModels/CustomPinViewModel.cs)                       | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/ViewModels/CustomPinViewModel.cs`            |
| [PinViewViewModel.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/ViewModels/PinViewViewModel.cs)                           | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/ViewModels/PinViewViewModel.cs`              |
| [BaseViewModel.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/ViewModels/BaseViewModel.cs)                                 | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/ViewModels/BaseViewModel.cs`                 |

</details>

<details closed><summary>Arduino_WPF.Arduino_WPF.Views</summary>

| File                                                                                                                                              | Summary                                                                                |
| ---                                                                                                                                               | ---                                                                                    |
| [CustomPin.xaml](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Views/CustomPin.xaml)                             | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Views/CustomPin.xaml`               |
| [CustomPin.xaml.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Views/CustomPin.xaml.cs)                       | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Views/CustomPin.xaml.cs`            |
| [SerialConnectionView.xaml.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Views/SerialConnectionView.xaml.cs) | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Views/SerialConnectionView.xaml.cs` |
| [SerialMonitorWindow.xaml](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Views/SerialMonitorWindow.xaml)         | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Views/SerialMonitorWindow.xaml`     |
| [SerialConnectionView.xaml](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Views/SerialConnectionView.xaml)       | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Views/SerialConnectionView.xaml`    |
| [MainWindow.xaml](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Views/MainWindow.xaml)                           | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Views/MainWindow.xaml`              |
| [PinView.xaml.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Views/PinView.xaml.cs)                           | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Views/PinView.xaml.cs`              |
| [SerialMonitorWindow.xaml.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Views/SerialMonitorWindow.xaml.cs)   | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Views/SerialMonitorWindow.xaml.cs`  |
| [MainWindow.xaml.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Views/MainWindow.xaml.cs)                     | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Views/MainWindow.xaml.cs`           |
| [PinView.xaml](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Views/PinView.xaml)                                 | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Views/PinView.xaml`                 |

</details>

<details closed><summary>Arduino_WPF.Arduino_WPF.Models</summary>

| File                                                                                                           | Summary                                                               |
| ---                                                                                                            | ---                                                                   |
| [COM.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Models/COM.cs)         | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Models/COM.cs`     |
| [Pin.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Models/Pin.cs)         | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Models/Pin.cs`     |
| [PinMode.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Models/PinMode.cs) | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Models/PinMode.cs` |

</details>

<details closed><summary>Arduino_WPF.Arduino_WPF.Utils</summary>

| File                                                                                                                                                  | Summary                                                                                  |
| ---                                                                                                                                                   | ---                                                                                      |
| [RelayCommand.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Utils/RelayCommand.cs)                               | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Utils/RelayCommand.cs`                |
| [StringToVisibilityConverter.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Utils/StringToVisibilityConverter.cs) | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Utils/StringToVisibilityConverter.cs` |
| [RelayCommandWithParameter.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Utils/RelayCommandWithParameter.cs)     | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Utils/RelayCommandWithParameter.cs`   |
| [PresetJsonLoader.cs](https://github.com/FelixLatzer/Arduino_WPF/blob/master/Arduino_WPF/Arduino_WPF/Utils/PresetJsonLoader.cs)                       | HTTP error 429 for prompt `Arduino_WPF/Arduino_WPF/Utils/PresetJsonLoader.cs`            |

</details>

<details closed><summary>external.JsonArduino</summary>

| File                                                                                                           | Summary                                                          |
| ---                                                                                                            | ---                                                              |
| [JsonArduino.ino](https://github.com/FelixLatzer/Arduino_WPF/blob/master/external/JsonArduino/JsonArduino.ino) | HTTP error 429 for prompt `external/JsonArduino/JsonArduino.ino` |

</details>

<details closed><summary>external.SimpleReceiveData</summary>

| File                                                                                                                             | Summary                                                                      |
| ---                                                                                                                              | ---                                                                          |
| [SimpleReceiveData.ino](https://github.com/FelixLatzer/Arduino_WPF/blob/master/external/SimpleReceiveData/SimpleReceiveData.ino) | HTTP error 429 for prompt `external/SimpleReceiveData/SimpleReceiveData.ino` |

</details>

<details closed><summary>external.ExtendedSimpleTransmitReceivce</summary>

| File                                                                                                                                                                    | Summary                                                                                                |
| ---                                                                                                                                                                     | ---                                                                                                    |
| [ExtendedSimpleTransmitReceivce.ino](https://github.com/FelixLatzer/Arduino_WPF/blob/master/external/ExtendedSimpleTransmitReceivce/ExtendedSimpleTransmitReceivce.ino) | HTTP error 429 for prompt `external/ExtendedSimpleTransmitReceivce/ExtendedSimpleTransmitReceivce.ino` |

</details>

<details closed><summary>external.COM.MoreSerialSettingsTest</summary>

| File                                                                                                                                                | Summary                                                                                    |
| ---                                                                                                                                                 | ---                                                                                        |
| [MoreSerialSettingsTest.ino](https://github.com/FelixLatzer/Arduino_WPF/blob/master/external/COM/MoreSerialSettingsTest/MoreSerialSettingsTest.ino) | HTTP error 429 for prompt `external/COM/MoreSerialSettingsTest/MoreSerialSettingsTest.ino` |

</details>

<details closed><summary>external.COM.COMTests</summary>

| File                                                                                                      | Summary                                                        |
| ---                                                                                                       | ---                                                            |
| [COMTests.ino](https://github.com/FelixLatzer/Arduino_WPF/blob/master/external/COM/COMTests/COMTests.ino) | HTTP error 429 for prompt `external/COM/COMTests/COMTests.ino` |

</details>

<details closed><summary>external.COM.ArduinoTestSerialOutput</summary>

| File                                                                                                                                                   | Summary                                                                                      |
| ---                                                                                                                                                    | ---                                                                                          |
| [ArduinoTestSerialOutput.ino](https://github.com/FelixLatzer/Arduino_WPF/blob/master/external/COM/ArduinoTestSerialOutput/ArduinoTestSerialOutput.ino) | HTTP error 429 for prompt `external/COM/ArduinoTestSerialOutput/ArduinoTestSerialOutput.ino` |

</details>

---

##  Getting Started

***Requirements***

Ensure you have the following dependencies installed on your system:

* **CSharp**: `version x.y.z`

###  Installation

1. Clone the  repository:

```sh
git clone https://github.com/FelixLatzer/Arduino_WPF/
```

2. Change to the project directory:

```sh
cd 
```

3. Install the dependencies:

```sh
dotnet build
```

###  Running 

Use the following command to run :

```sh
dotnet run
```

###  Tests

To execute tests, run:

```sh
dotnet test
```

---

##  Project Roadmap

- [X] `► INSERT-TASK-1`
- [ ] `► INSERT-TASK-2`
- [ ] `► ...`

---

##  Contributing

Contributions are welcome! Here are several ways you can contribute:

- **[Submit Pull Requests](https://github.com/FelixLatzer/Arduino_WPF/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.
- **[Join the Discussions](https://github.com/FelixLatzer/Arduino_WPF/discussions)**: Share your insights, provide feedback, or ask questions.
- **[Report Issues](https://github.com/FelixLatzer/Arduino_WPF/issues)**: Submit bugs found or log feature requests for .

<details closed>
    <summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your GitHub account.
2. **Clone Locally**: Clone the forked repository to your local machine using a Git client.
   ```sh
   git clone https://github.com/FelixLatzer/Arduino_WPF/
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to GitHub**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.

Once your PR is reviewed and approved, it will be merged into the main branch.

</details>

---

##  License

This project is protected under the [SELECT-A-LICENSE](https://choosealicense.com/licenses) License. For more details, refer to the [LICENSE](https://choosealicense.com/licenses/) file.

---

##  Acknowledgments

- List any resources, contributors, inspiration, etc. here.

[**Return**](#-quick-links)

---
