var MyPlugin = 
{
isMobile: function()
{
return Module.SystemInfo.mobile;
}

};

mergeInto(LibraryManager.library,MyPlugin);