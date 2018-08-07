using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using Crestron.TV_Presets.User_Interfaces;
using Crestron.TV_Presets.File_Manager;
using Crestron.TV_Presets;
using Crestron.CRPC;
using Crestron.CRPC.CIPDirectTransport;
using Crestron.CRPC.Common;
using CRPCConnectionHelper;

namespace CrestronModule_TV_PRESETS_FILE_MANAGER_INTERFACE_V1_2
{
    public class CrestronModuleClass_TV_PRESETS_FILE_MANAGER_INTERFACE_V1_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput LOADPROFILES;
        Crestron.Logos.SplusObjects.DigitalInput REFRESHFILES;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PINREQUIREDFORPROFILE;
        Crestron.Logos.SplusObjects.AnalogInput WEBSERVERPORT;
        Crestron.Logos.SplusObjects.AnalogInput CONNECTIONTYPE;
        Crestron.Logos.SplusObjects.StringInput PIN;
        Crestron.Logos.SplusObjects.StringInput CUSTOMICONURL;
        Crestron.Logos.SplusObjects.StringInput CUSTOMLANGUAGEFILEURL;
        Crestron.Logos.SplusObjects.StringInput CUSTOMPROVIDERFILEURL;
        Crestron.Logos.SplusObjects.StringInput DEFAULTLANGUAGEFILEFILENAME;
        Crestron.Logos.SplusObjects.StringInput DEFAULTPROVIDERFILEFILENAME;
        Crestron.Logos.SplusObjects.StringInput WEBSERVERUSERNAME;
        Crestron.Logos.SplusObjects.StringInput WEBSERVERPASSWORD;
        ushort INITIALIZED = 0;
        private ushort WAITFORSSHARPINITIALIZATION (  SplusExecutionContext __context__ ) 
            { 
            ushort WAITCOUNT = 0;
            
            
            __context__.SourceCodeLine = 44;
            WAITCOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 46;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (INITIALIZED == 0) ) && Functions.TestForTrue ( Functions.BoolToInt ( WAITCOUNT < 300 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 48;
                Functions.Delay (  (int) ( 100 ) ) ; 
                __context__.SourceCodeLine = 49;
                WAITCOUNT = (ushort) ( (WAITCOUNT + 1) ) ; 
                __context__.SourceCodeLine = 46;
                } 
            
            __context__.SourceCodeLine = 51;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( WAITCOUNT >= 300 ))  ) ) 
                { 
                __context__.SourceCodeLine = 53;
                return (ushort)( 0) ; 
                } 
            
            __context__.SourceCodeLine = 56;
            return (ushort)( 1) ; 
            
            }
            
        object LOADPROFILES_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort INDEX = 0;
                
                
                __context__.SourceCodeLine = 63;
                if ( Functions.TestForTrue  ( ( WAITFORSSHARPINITIALIZATION( __context__ ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 65;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)30; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( INDEX  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (INDEX  >= __FN_FORSTART_VAL__1) && (INDEX  <= __FN_FOREND_VAL__1) ) : ( (INDEX  <= __FN_FORSTART_VAL__1) && (INDEX  >= __FN_FOREND_VAL__1) ) ; INDEX  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 67;
                         TVPresetsFileManager.LoadProfile( (ushort)( (INDEX - 1) ) , (ushort)( PINREQUIREDFORPROFILE[ INDEX ] .Value ) ,  DEFAULTLANGUAGEFILEFILENAME .ToString() ,  DEFAULTPROVIDERFILEFILENAME .ToString() )  ;  
 
                        __context__.SourceCodeLine = 65;
                        } 
                    
                    __context__.SourceCodeLine = 70;
                     TVPresetsFileManager.ProfilesLoaded  =  (ushort)( 1 )  ;  
 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 74;
                    GenerateUserNotice ( "TV Presets File Manager Interface: Initialization Wait exceeded 5 minutes... Unable to load profiles.") ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object REFRESHFILES_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 80;
            if ( Functions.TestForTrue  ( ( INITIALIZED)  ) ) 
                { 
                __context__.SourceCodeLine = 82;
                 TVPresetProjectSettings.RefreshFiles()  ;  
 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object CUSTOMICONURL_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 87;
        if ( Functions.TestForTrue  ( ( WAITFORSSHARPINITIALIZATION( __context__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 89;
             TVPresetProjectSettings.IconURL  =( CUSTOMICONURL )  .ToString()  ;  
 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 93;
            GenerateUserNotice ( "TV Presets File Manager Interface: Initialization Wait exceeded 5 minutes... Unable to set CustomIconUrl.") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CUSTOMLANGUAGEFILEURL_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 100;
        if ( Functions.TestForTrue  ( ( WAITFORSSHARPINITIALIZATION( __context__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 102;
             TVPresetProjectSettings.LanguageFileURL  =( CUSTOMLANGUAGEFILEURL )  .ToString()  ;  
 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 106;
            GenerateUserNotice ( "TV Presets File Manager Interface: Initialization Wait exceeded 5 minutes... Unable to set CustomLanguageFileUrl.") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CUSTOMPROVIDERFILEURL_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 113;
        if ( Functions.TestForTrue  ( ( WAITFORSSHARPINITIALIZATION( __context__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 115;
             TVPresetProjectSettings.ProviderFileURL  =( CUSTOMPROVIDERFILEURL )  .ToString()  ;  
 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 119;
            GenerateUserNotice ( "TV Presets File Manager Interface: Initialization Wait exceeded 5 minutes... Unable to set CustomProviderFileUrl.") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PIN_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 125;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PIN != ""))  ) ) 
            {
            __context__.SourceCodeLine = 126;
             TVPresetsFileManager.ModuleAssignedPin  =( PIN )  .ToString()  ;  
 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object WEBSERVERUSERNAME_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
         TVPresetProjectSettings.WebserverUsername  =( WEBSERVERUSERNAME )  .ToString()  ;  
 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object WEBSERVERPASSWORD_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
         TVPresetProjectSettings.WebserverPassword  =( WEBSERVERPASSWORD )  .ToString()  ;  
 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object WEBSERVERPORT_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 141;
        if ( Functions.TestForTrue  ( ( WAITFORSSHARPINITIALIZATION( __context__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 143;
             TVPresetProjectSettings.WebserverPort  =  (int)( WEBSERVERPORT  .IntValue )  ;  
 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 147;
            GenerateUserNotice ( "TV Presets File Manager Interface: Initialization Wait exceeded 5 minutes... Unable to set WebserverPort.") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONNECTIONTYPE_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 153;
        if ( Functions.TestForTrue  ( ( WAITFORSSHARPINITIALIZATION( __context__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 155;
             TVPresetProjectSettings.WebserverConnectionType  =  (int)( CONNECTIONTYPE  .IntValue )  ;  
 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 159;
            GenerateUserNotice ( "TV Presets File Manager Interface: Initialization Wait exceeded 5 minutes... Unable to set WebserverConnectionType.") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 165;
        INITIALIZED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 166;
         TVPresetsFileManager.Initialize()  ;  
 
        __context__.SourceCodeLine = 167;
        INITIALIZED = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    LOADPROFILES = new Crestron.Logos.SplusObjects.DigitalInput( LOADPROFILES__DigitalInput__, this );
    m_DigitalInputList.Add( LOADPROFILES__DigitalInput__, LOADPROFILES );
    
    REFRESHFILES = new Crestron.Logos.SplusObjects.DigitalInput( REFRESHFILES__DigitalInput__, this );
    m_DigitalInputList.Add( REFRESHFILES__DigitalInput__, REFRESHFILES );
    
    PINREQUIREDFORPROFILE = new InOutArray<DigitalInput>( 30, this );
    for( uint i = 0; i < 30; i++ )
    {
        PINREQUIREDFORPROFILE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PINREQUIREDFORPROFILE__DigitalInput__ + i, PINREQUIREDFORPROFILE__DigitalInput__, this );
        m_DigitalInputList.Add( PINREQUIREDFORPROFILE__DigitalInput__ + i, PINREQUIREDFORPROFILE[i+1] );
    }
    
    WEBSERVERPORT = new Crestron.Logos.SplusObjects.AnalogInput( WEBSERVERPORT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( WEBSERVERPORT__AnalogSerialInput__, WEBSERVERPORT );
    
    CONNECTIONTYPE = new Crestron.Logos.SplusObjects.AnalogInput( CONNECTIONTYPE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( CONNECTIONTYPE__AnalogSerialInput__, CONNECTIONTYPE );
    
    PIN = new Crestron.Logos.SplusObjects.StringInput( PIN__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( PIN__AnalogSerialInput__, PIN );
    
    CUSTOMICONURL = new Crestron.Logos.SplusObjects.StringInput( CUSTOMICONURL__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( CUSTOMICONURL__AnalogSerialInput__, CUSTOMICONURL );
    
    CUSTOMLANGUAGEFILEURL = new Crestron.Logos.SplusObjects.StringInput( CUSTOMLANGUAGEFILEURL__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( CUSTOMLANGUAGEFILEURL__AnalogSerialInput__, CUSTOMLANGUAGEFILEURL );
    
    CUSTOMPROVIDERFILEURL = new Crestron.Logos.SplusObjects.StringInput( CUSTOMPROVIDERFILEURL__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( CUSTOMPROVIDERFILEURL__AnalogSerialInput__, CUSTOMPROVIDERFILEURL );
    
    DEFAULTLANGUAGEFILEFILENAME = new Crestron.Logos.SplusObjects.StringInput( DEFAULTLANGUAGEFILEFILENAME__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( DEFAULTLANGUAGEFILEFILENAME__AnalogSerialInput__, DEFAULTLANGUAGEFILEFILENAME );
    
    DEFAULTPROVIDERFILEFILENAME = new Crestron.Logos.SplusObjects.StringInput( DEFAULTPROVIDERFILEFILENAME__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( DEFAULTPROVIDERFILEFILENAME__AnalogSerialInput__, DEFAULTPROVIDERFILEFILENAME );
    
    WEBSERVERUSERNAME = new Crestron.Logos.SplusObjects.StringInput( WEBSERVERUSERNAME__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( WEBSERVERUSERNAME__AnalogSerialInput__, WEBSERVERUSERNAME );
    
    WEBSERVERPASSWORD = new Crestron.Logos.SplusObjects.StringInput( WEBSERVERPASSWORD__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( WEBSERVERPASSWORD__AnalogSerialInput__, WEBSERVERPASSWORD );
    
    
    LOADPROFILES.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOADPROFILES_OnPush_0, false ) );
    REFRESHFILES.OnDigitalPush.Add( new InputChangeHandlerWrapper( REFRESHFILES_OnPush_1, false ) );
    CUSTOMICONURL.OnSerialChange.Add( new InputChangeHandlerWrapper( CUSTOMICONURL_OnChange_2, false ) );
    CUSTOMLANGUAGEFILEURL.OnSerialChange.Add( new InputChangeHandlerWrapper( CUSTOMLANGUAGEFILEURL_OnChange_3, false ) );
    CUSTOMPROVIDERFILEURL.OnSerialChange.Add( new InputChangeHandlerWrapper( CUSTOMPROVIDERFILEURL_OnChange_4, false ) );
    PIN.OnSerialChange.Add( new InputChangeHandlerWrapper( PIN_OnChange_5, false ) );
    WEBSERVERUSERNAME.OnSerialChange.Add( new InputChangeHandlerWrapper( WEBSERVERUSERNAME_OnChange_6, false ) );
    WEBSERVERPASSWORD.OnSerialChange.Add( new InputChangeHandlerWrapper( WEBSERVERPASSWORD_OnChange_7, false ) );
    WEBSERVERPORT.OnAnalogChange.Add( new InputChangeHandlerWrapper( WEBSERVERPORT_OnChange_8, false ) );
    CONNECTIONTYPE.OnAnalogChange.Add( new InputChangeHandlerWrapper( CONNECTIONTYPE_OnChange_9, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_TV_PRESETS_FILE_MANAGER_INTERFACE_V1_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint LOADPROFILES__DigitalInput__ = 0;
const uint REFRESHFILES__DigitalInput__ = 1;
const uint PINREQUIREDFORPROFILE__DigitalInput__ = 2;
const uint WEBSERVERPORT__AnalogSerialInput__ = 0;
const uint CONNECTIONTYPE__AnalogSerialInput__ = 1;
const uint PIN__AnalogSerialInput__ = 2;
const uint CUSTOMICONURL__AnalogSerialInput__ = 3;
const uint CUSTOMLANGUAGEFILEURL__AnalogSerialInput__ = 4;
const uint CUSTOMPROVIDERFILEURL__AnalogSerialInput__ = 5;
const uint DEFAULTLANGUAGEFILEFILENAME__AnalogSerialInput__ = 6;
const uint DEFAULTPROVIDERFILEFILENAME__AnalogSerialInput__ = 7;
const uint WEBSERVERUSERNAME__AnalogSerialInput__ = 8;
const uint WEBSERVERPASSWORD__AnalogSerialInput__ = 9;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
