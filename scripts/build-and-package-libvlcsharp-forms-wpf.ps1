param([string]$msbuild)

Remove-Item ..\LibVLCSharp.Forms.Platforms.WPF\bin -Force -Recurse -ErrorAction Ignore
Remove-Item ..\LibVLCSharp.Forms.Platforms.WPF\obj -Force -Recurse -ErrorAction Ignore

iex ("& {0} {1}" -f $msbuild, "../LibVLCSharp.Forms.Platforms.WPF/LibVLCSharp.Forms.Platforms.WPF.csproj /t:Restore,Clean,Build /p:Configuration=Release")

robocopy  ..\LibVLCSharp.Forms.Platforms.WPF\bin\Release\ . *.nupkg