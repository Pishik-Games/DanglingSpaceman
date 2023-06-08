var MyPlugin = {
    IsMobile: function(){
        return Module.SystemInfo.mobile;

    }
};

mergeInto(LibraryManager.library, MyPlugin);