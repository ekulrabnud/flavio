namespace Crestron.TV_Presets.User_Interfaces;
        // class declarations
         class TVPresetCrpcInitialization;
         class TVPresetsCrpcInterface;
         class TVPresetsMLX3Interface;
         class TVPresetsStateChangedEventArgs;
         class TVPresetsUpdatePresetEventArgs;
         class TVPresetsUpdatePresetRangeEventArgs;
         class TVPresetsNewProfileSelectedEventArgs;
         class TVPresetsStatusMsgEventArgs;
     class TVPresetCrpcInitialization 
    {
        // class delegates
        delegate FUNCTION DelegateFnString ( SIMPLSHARPSTRING myString );

        // class events

        // class functions
        FUNCTION InitializeTVPresetsCrpc ( INTEGER port , INTEGER adapterID , TVPresetsCrpcInterface TVPresets );
        FUNCTION JoinTransportSendback ( STRING stream );
        FUNCTION MessageIn ( STRING pkt );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty DelegateFnString MessageOut;
    };

     class TVPresetsCrpcInterface 
    {
        // class delegates
        delegate FUNCTION DelegateFnString ( SIMPLSHARPSTRING myString );

        // class events
        EventHandler stateChanged ( TVPresetsCrpcInterface sender, TVPresetsStateChangedEventArgs args );
        EventHandler updatePreset ( TVPresetsCrpcInterface sender, TVPresetsUpdatePresetEventArgs args );
        EventHandler updatePresetRange ( TVPresetsCrpcInterface sender, TVPresetsUpdatePresetRangeEventArgs args );
        EventHandler newProfileSelected ( TVPresetsCrpcInterface sender, TVPresetsNewProfileSelectedEventArgs args );
        EventHandler statusMsg ( TVPresetsCrpcInterface sender, TVPresetsStatusMsgEventArgs args );

        // class functions
        FUNCTION SelectProfile ( INTEGER profileIndex );
        FUNCTION LoadURLs ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER selectedProfileIndex;
        STRING Name[];
        INTEGER adapterID;

        // class properties
        DelegateProperty DelegateFnString ChannelSelected;
        SIGNED_LONG_INTEGER presetCount;
        STRING languageFileUrl[];
        STRING providerFileUrl[];
        STRING iconsUrl[];
        STRING language[];
        STRING provider[];
        SIGNED_LONG_INTEGER sortOrder;
        STRING lastFileUpdateTime[];
        STRING lastProfileUpdateTime[];
        STRING username[];
        STRING password[];
    };

     class TVPresetsMLX3Interface 
    {
        // class delegates
        delegate FUNCTION DelegateFnIntIntString ( INTEGER myUshort1 , INTEGER myUshort2 , SIMPLSHARPSTRING myString );
        delegate FUNCTION DelegateFnInt ( INTEGER myUshort );
        delegate FUNCTION DelegateFnString ( SIMPLSHARPSTRING myString );

        // class events

        // class functions
        FUNCTION SelectProfile ( INTEGER profileIndex );
        FUNCTION triggerPreset ( INTEGER presetIndex );
        FUNCTION getPresets ( SIGNED_LONG_INTEGER item , SIGNED_LONG_INTEGER count );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER selectedProfileIndex;

        // class properties
        DelegateProperty DelegateFnIntIntString SetPreset;
        DelegateProperty DelegateFnInt SetPresetCount;
        DelegateProperty DelegateFnString ChannelSelected;
    };

     class TVPresetsStateChangedEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class TVPresetsNewProfileSelectedEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace Crestron.TV_Presets.File_Manager;
        // class declarations
         class ManifestManager;
         class Language;
         class Provider;
         class Icon;
         class TVPresetProjectSettings;
     class ManifestManager 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION CreateLanguageManifest ( STRING directory , STRING manifestFilename );
        FUNCTION CreateProviderManifest ( STRING directory , STRING manifestFilename );
        FUNCTION CreateIconManifest ( STRING directory , STRING manifestFilename );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class Language 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        STRING Filename[];
    };

     class Provider 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        STRING Filename[];
    };

     class Icon 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        STRING Filename[];
    };

    static class TVPresetProjectSettings 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION RefreshFiles ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING LocalLanguageFileURL[];
        static STRING LANLanguageFileURL[];
        static STRING LocalProviderFileURL[];
        static STRING LANProviderFileURL[];
        static STRING LocalIconFileURL[];
        static STRING LANIconFileURL[];

        // class properties
        STRING lastFileUpdateTime[];
        STRING LanguageFileURL[];
        STRING ProviderFileURL[];
        STRING IconURL[];
        STRING WebserverUsername[];
        STRING WebserverPassword[];
        SIGNED_LONG_INTEGER WebserverPort;
        SIGNED_LONG_INTEGER WebserverConnectionType;
        STRING Pin[];
    };

namespace Crestron.TV_Presets;
        // class declarations
         class Profile;
         class Preset;
         class ChangeEvent;
         class SortOptions;
         class TVPresetsFileManager;
     class Profile 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING LanguageFilename[];
        STRING ProviderFilename[];
        STRING LastProfileUpdateTime[];
        Crestron.TV_Presets.SortOptions SortOrder;

        // class properties
    };

     class Preset 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING name[];
        STRING customName[];
        STRING image[];
        STRING channel[];
        STRING id[];
    };

    static class ChangeEvent // enum
    {
        static SIGNED_LONG_INTEGER Add;
        static SIGNED_LONG_INTEGER Edit;
        static SIGNED_LONG_INTEGER Move;
        static SIGNED_LONG_INTEGER Delete;
    };

    static class SortOptions // enum
    {
        static SIGNED_LONG_INTEGER Unsorted;
        static SIGNED_LONG_INTEGER ChannelNumber;
        static SIGNED_LONG_INTEGER ChannelName;
    };

    static class TVPresetsFileManager 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION Initialize ();
        static FUNCTION LoadProfile ( INTEGER index , INTEGER pinRequired , STRING defaultLanguageFilename , STRING defaultProviderFilename );
        static FUNCTION SaveProfile ( INTEGER index );
        static FUNCTION SaveSettings ();
        static FUNCTION SetPin ( STRING newPin );
        static FUNCTION SetLanguage ( INTEGER profileIndex , STRING languageFilename );
        static FUNCTION SetProvider ( INTEGER profileIndex , STRING providerFilename );
        static FUNCTION AddPresetV ( INTEGER profileIndex , STRING name , STRING customName , STRING image , STRING channel , SIGNED_LONG_INTEGER presetIndex );
        static FUNCTION DeletePresetV ( INTEGER profileIndex , SIGNED_LONG_INTEGER presetIndex );
        static FUNCTION DeletePresetByIDV ( INTEGER profileIndex , STRING ID );
        static FUNCTION MovePresetV ( INTEGER profileIndex , SIGNED_LONG_INTEGER srcPresetIndex , SIGNED_LONG_INTEGER destPresetIndex );
        static FUNCTION MovePresetByIDV ( INTEGER profileIndex , STRING srcPresetID , SIGNED_LONG_INTEGER destPresetIndex );
        static FUNCTION EditPresetV ( INTEGER profileIndex , SIGNED_LONG_INTEGER presetIndex , STRING name , STRING customName , STRING image , STRING channel );
        static FUNCTION EditPresetByIDV ( INTEGER profileIndex , STRING presetID , STRING name , STRING customName , STRING image , STRING channel );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static INTEGER MaxProfiles;

        // class properties
        STRING ModuleAssignedPin[];
        INTEGER ProfilesLoaded;
        STRING Pin[];
    };

