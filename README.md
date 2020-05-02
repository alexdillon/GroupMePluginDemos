# GroupMe Desktop Client Plugin Demos
Samples for the Group-Chat Option Plugin and the Message Composer Plugin
- EffectDemo: Basic template for a message composer plugin. This plugin format can be used to offer message suggestions based on what a user has typed.
- GroupPluginDemoWPF-MVVM: Group Plugins can be invoked for a specific Group or Chat (direct message) from the dropdown menu at the top. This is demo that opens a  WPF window and displays the name of the selected group. The most recent message in the group is shown from cache, as well as the most recently cached message (from any group). MvvmLight is included.

## Build
In order to build the plugins, they must have references to GroupMeClientApi and GroupMeClientPlugin from the GroupMeClient repository. 
If the references show as unresolved (yellow triangle) in Visual Studio, remove the reference. Then, add it back pointing to the correct path.

## Install
- Create the folder ```%localappdata%\MicroCube\GroupMe Desktop Client\Plugins``` if it does not exist
- Copy the generated .dll file from the ```\bin\Debug\``` into the ```Plugins``` directory. 
  - Only the single dll needs copied. The build directory will have copies of ```GroupMeClientApi.dll``` and ```GroupMeClientPlugin.dll```. These can be omitted, since they are already installed with the Desktop Client.
  - For the MVVM Demo, the Galasoft/MvvmLight dlls can also be omitted. The Desktop Client already targets the same version of MvvmLight.
  
## Test
- Run the GroupMe Desktop Client
- Open a Group or Chat
- Select the dropdown arrow next to the group name (above the messages) to open the Group Options menu.
- Select one of the installed GroupPlugin demos. For both, a plain window should be displayed containing the Group or Chat name.
