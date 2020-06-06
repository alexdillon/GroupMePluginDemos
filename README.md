# GroupMe Desktop Client Plugin Demos
Samples for the Group-Chat Option Plugin and the Message Composer Plugin
- EffectDemo: Basic template for a message composer plugin. This plugin format can be used to offer message suggestions based on what a user has typed.
- GroupPluginDemoWPF-MVVM: Group Plugins can be invoked for a specific Group or Chat (direct message) from the dropdown menu at the top. This is demo that opens a  WPF window and displays the name of the selected group. The most recent message in the group is shown from cache, as well as the most recently cached message (from any group). MvvmLight is included.

## Build
Both the GroupMeClientApi and GroupMeClientPlugin packages required to build the demo are hosted on NuGet.
The sample solution includes a binary copy of the packaging tool, which is automatically run upon a 'Release' build.

## Install (Standard Manual Method)
- Create the folder ```%localappdata%\MicroCube\GroupMe Desktop Client\Plugins``` if it does not exist
- Copy the generated .dll file from the ```\bin\Debug\``` into the ```Plugins``` directory. 
  - Only the single dll needs copied. The build directory will have copies of ```GroupMeClientApi.dll``` and ```GroupMeClientPlugin.dll```. These can be omitted, since they are already installed with the Desktop Client.
  - For the MVVM Demo, the Galasoft/MvvmLight dlls can also be omitted. The Desktop Client already targets the same version of MvvmLight.
  - See the Publishing section for more details about configuring unneccesary dependencies to be omitted.
  
## (Optional) Static Installation
- Instead of copying the plugin binaries into the ```Plugins``` folder and loading them dynamically at runtime, it may be easier to compile a special debug version of GroupMe Desktop Client that statically links against your plugin.
- This method will allow you to fully step-through your plugin, view how it interacts with the GMDC Runtime, and better set breakpoints.
- To build a static test copy:
  - Clone the ```develop``` branch of GroupMe Desktop Client from GitHub.
  - Open the Solution in Visual Studio. Add your plugin project to the GMDC solution.
  - In the GroupMeClient project (the GMDC Core), add a "Shared Project" reference to your plugin project.
  - Edit ```Plugins\PluginManager.cs``` as follows:
	```csharp
	public void LoadPlugins(string pluginsPath)
	{
	   ... /*Add your code at the very bottom of the method */
	   
	   // For a Group Plugin
	   this.GroupChatPluginsManuallyInstalled.Add(new YourPluginProject.YourPlugin()); 
	   
	   // For a Effect Plugin
	   this.MessageComposePluginsManuallyInstalled.Add(new YourPluginProject.YourPlugin()); 
	}
	```
  - Run the project. Your plugin will be available, and all Visual Studio debugging features will be available.
  
## Test
- Run the GroupMe Desktop Client
- Open a Group or Chat
- Select the dropdown arrow next to the group name (above the messages) to open the Group Options menu.
- Select one of the installed GroupPlugin demos. For both, a plain window should be displayed containing the Group or Chat name.
- To see the Effect Demo, begin composing a message, and then select the icon to the left of the send box.

## Publishing
GroupMe Desktop Client v0.0.25 and newer include support for automatically installing and updating plugins from online repositories. GitHub Releases are supported and are the recommended method for distributing plugins.
The sample solution comes pre-configured to generate the RELEASES file and zip bundles for automatic installation. To apply this packaging to plugins in another solution, the following steps can be used.

- Copy the ```PackageForReleaseTools``` folder into the root of your solution. 
- Edit the .csproj file for your plugin. Include the following section in the project file:

   ```xml
   <Target Name="PackageForRelease" AfterTargets="Build" Condition=" '$(Configuration)' == 'Release'">
     <Message Text="Packaging for Release...." Importance="High" />

     <GetAssemblyIdentity AssemblyFiles="$(TargetPath)">
       <Output TaskParameter="Assemblies" ItemName="myAssemblyInfo" />
     </GetAssemblyIdentity>

     <Exec Command="&quot;$(SolutionDir)\PackageForReleaseTools\PackageForRelease.exe&quot; --shortname $(ProjectName) --fullname &quot;PUT THE FULL DISPLAY NAME HERE&quot; --bindir &quot;$(OutDir)\&quot; --pubdir &quot;$(OutDir)\..\..\..\\Publish\\&quot; --version &quot;$([System.Version]::Parse(%(myAssemblyInfo.Version)).ToString(3))&quot;" />
   </Target>
   ```
   
   - Replace ```PUT THE FULL NAME HERE``` with the complete display name of your plugin, or select a MSBuild variable to use. This string will be shown in the GMDC Repo Browser to identify your plugin.
   - The ```pubdir``` parameter indicates the folder where the resulting RELEASES file and zip bundles should be stored. The number of ```..\``` paths may need to be adjusted relative to your solution structure. The sample path is a typical representation for a .NET Framework project nested in a solution.
   
- All artifacts produced in the ```bindir``` folder will be bundled with your plugin. Some dependencies, such as GroupMeClientApi and GroupMePlugin should NOT be included though, since they are already provided at runtime by GMDC. The same applies for MahApps Metro (if used) and MvvmLight for graphical plugins. To exclude these dependencies from being included in a release build, update the .csproj as shown below.
   
   ```xml
	<PackageReference Include="GroupMeClientPlugin">
      <Version>2.0.0</Version>
      <ExcludeAssets>runtime</ExcludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
   ```
   
   - Note the inclusion of the ```<ExcludeAssets>runtime</ExcludeAssets>``` and ```<PrivateAssets>all</PrivateAssets>``` lines.
   - These should be included for GroupMeClientApi, GroupMeClientPlugin, MahApps Metro, MvvmLight, and System.ComponentModel.Annotations.
- To run the packaging tool, build in Release mode.
- Prior to producing a final release build, empty the contents of the Publish folder. The packaging tool appends a new line onto the RELEASES file for each plugin, however, it does not update old entries. This can result in duplicate entries if numerous release builds have been done with the same version number without clearing the folder first. 
- Create a GitHub release and ensure that all packaged artifacts are uploaded to the release. This includes the RELEASES.txt file and all .zip packages. None of the files should be renamed. 