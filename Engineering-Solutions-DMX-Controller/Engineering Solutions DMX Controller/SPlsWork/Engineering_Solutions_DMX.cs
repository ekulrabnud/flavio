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

namespace UserModule_ENGINEERING_SOLUTIONS_DMX
{
    public class UserModuleClass_ENGINEERING_SOLUTIONS_DMX : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput SHOWTIME;
        Crestron.Logos.SplusObjects.DigitalInput ALLOFF;
        Crestron.Logos.SplusObjects.DigitalInput ALLON;
        Crestron.Logos.SplusObjects.DigitalInput SLIDERRELEASE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> RECALLPRESET;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SAVEPRESET;
        Crestron.Logos.SplusObjects.AnalogInput RED;
        Crestron.Logos.SplusObjects.AnalogInput GREEN;
        Crestron.Logos.SplusObjects.AnalogInput BLUE;
        Crestron.Logos.SplusObjects.AnalogInput FADETIME;
        Crestron.Logos.SplusObjects.DigitalOutput SHOWTIMEFB;
        Crestron.Logos.SplusObjects.AnalogOutput REDFB;
        Crestron.Logos.SplusObjects.AnalogOutput GREENFB;
        Crestron.Logos.SplusObjects.AnalogOutput BLUEFB;
        Crestron.Logos.SplusObjects.AnalogOutput FADETIMEFB;
        Crestron.Logos.SplusObjects.StringOutput TODMX;
        Crestron.Logos.SplusObjects.StringOutput FADETIMETEXT;
        UShortParameter DMXID;
        ushort SHOWTIMEPOINTER = 0;
        private void SENDRGB (  SplusExecutionContext __context__, ushort IFADETIME ) 
            { 
            
            __context__.SourceCodeLine = 33;
            MakeString ( TODMX , "F{0:d3}@{1:d3},{2:d3}@{3:d3},{4:d3}@{5:d3}:{6:d3}\u000D", (ushort)DMXID  .Value, (ushort)RED  .UshortValue, (ushort)(DMXID  .Value + 1), (ushort)GREEN  .UshortValue, (ushort)(DMXID  .Value + 2), (ushort)BLUE  .UshortValue, (ushort)IFADETIME) ; 
            
            }
            
        object FADETIME_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 39;
                CreateWait ( "__SPLS_TMPVAR__WAITLABEL_0__" , 50 , __SPLS_TMPVAR__WAITLABEL_0___Callback ) ;
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void __SPLS_TMPVAR__WAITLABEL_0___CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            {
            __context__.SourceCodeLine = 39;
            MakeString ( FADETIMETEXT , "{0:d} Sec", (ushort)(FADETIMEFB  .Value / 10)) ; 
            }
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void EXEPRESET (  SplusExecutionContext __context__, ushort INDEX , ushort FADEFLAG ) 
    { 
    
    __context__.SourceCodeLine = 45;
    REDFB  .Value = (ushort) ( _SplusNVRAM.PRESET[ INDEX ].SRED ) ; 
    __context__.SourceCodeLine = 46;
    GREENFB  .Value = (ushort) ( _SplusNVRAM.PRESET[ INDEX ].SGREEN ) ; 
    __context__.SourceCodeLine = 47;
    BLUEFB  .Value = (ushort) ( _SplusNVRAM.PRESET[ INDEX ].SBLUE ) ; 
    __context__.SourceCodeLine = 48;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FADEFLAG == 0))  ) ) 
        {
        __context__.SourceCodeLine = 48;
        FADETIMEFB  .Value = (ushort) ( _SplusNVRAM.PRESET[ INDEX ].SFADE ) ; 
        }
    
    else 
        {
        __context__.SourceCodeLine = 49;
        FADETIMEFB  .Value = (ushort) ( FADEFLAG ) ; 
        }
    
    __context__.SourceCodeLine = 50;
    MakeString ( FADETIMETEXT , "{0:d} Sec", (ushort)(FADETIMEFB  .Value / 10)) ; 
    __context__.SourceCodeLine = 51;
    SENDRGB (  __context__ , (ushort)( FADETIME  .UshortValue )) ; 
    
    }
    
private void RUNSHOWTIME (  SplusExecutionContext __context__, ushort SHOWTIMEWAITTIME ) 
    { 
    
    __context__.SourceCodeLine = 57;
    CreateWait ( "SHOWTIMEWAIT" , SHOWTIMEWAITTIME , SHOWTIMEWAIT_Callback ) ;
    
    }
    
public void SHOWTIMEWAIT_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 59;
            SHOWTIMEPOINTER = (ushort) ( (SHOWTIMEPOINTER + 1) ) ; 
            __context__.SourceCodeLine = 60;
            if ( Functions.TestForTrue  ( ( _SplusNVRAM.PRESET[ SHOWTIMEPOINTER ].ISUSED)  ) ) 
                { 
                __context__.SourceCodeLine = 62;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SHOWTIMEPOINTER > 10 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 62;
                    SHOWTIMEPOINTER = (ushort) ( 1 ) ; 
                    }
                
                __context__.SourceCodeLine = 63;
                EXEPRESET (  __context__ , (ushort)( SHOWTIMEPOINTER ), (ushort)( FADETIME  .UshortValue )) ; 
                __context__.SourceCodeLine = 64;
                RUNSHOWTIME (  __context__ , (ushort)( (FADETIME  .UshortValue * 20) )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 68;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHOWTIMEPOINTER == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 68;
                    SHOWTIMEFB  .Value = (ushort) ( 0 ) ; 
                    }
                
                else 
                    { 
                    __context__.SourceCodeLine = 69;
                    SHOWTIMEPOINTER = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 69;
                    RUNSHOWTIME (  __context__ , (ushort)( (FADETIME  .UshortValue * 20) )) ; 
                    } 
                
                } 
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object SHOWTIME_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 77;
        SHOWTIMEFB  .Value = (ushort) ( Functions.Not( SHOWTIMEFB  .Value ) ) ; 
        __context__.SourceCodeLine = 78;
        CancelWait ( "SHOWTIMEWAIT" ) ; 
        __context__.SourceCodeLine = 79;
        if ( Functions.TestForTrue  ( ( SHOWTIMEFB  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 81;
            SHOWTIMEPOINTER = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 82;
            RUNSHOWTIME (  __context__ , (ushort)( 10 )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SLIDERRELEASE_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 89;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHOWTIMEFB  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 89;
            SHOWTIMEFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 89;
            CancelWait ( "SHOWTIMEWAIT" ) ; 
            } 
        
        __context__.SourceCodeLine = 90;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_1__" , 30 , __SPLS_TMPVAR__WAITLABEL_1___Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void __SPLS_TMPVAR__WAITLABEL_1___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 90;
            SENDRGB (  __context__ , (ushort)( FADETIME  .UshortValue )) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object ALLON_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 96;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHOWTIMEFB  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 96;
            SHOWTIMEFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 96;
            CancelWait ( "SHOWTIMEWAIT" ) ; 
            } 
        
        __context__.SourceCodeLine = 97;
        REDFB  .Value = (ushort) ( 255 ) ; 
        __context__.SourceCodeLine = 98;
        GREENFB  .Value = (ushort) ( 255 ) ; 
        __context__.SourceCodeLine = 99;
        BLUEFB  .Value = (ushort) ( 255 ) ; 
        __context__.SourceCodeLine = 101;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_2__" , 30 , __SPLS_TMPVAR__WAITLABEL_2___Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void __SPLS_TMPVAR__WAITLABEL_2___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 101;
            SENDRGB (  __context__ , (ushort)( 0 )) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object ALLOFF_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 107;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHOWTIMEFB  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 107;
            SHOWTIMEFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 107;
            CancelWait ( "SHOWTIMEWAIT" ) ; 
            } 
        
        __context__.SourceCodeLine = 108;
        REDFB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 109;
        GREENFB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 110;
        BLUEFB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 112;
        CreateWait ( "__SPLS_TMPVAR__WAITLABEL_3__" , 30 , __SPLS_TMPVAR__WAITLABEL_3___Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void __SPLS_TMPVAR__WAITLABEL_3___CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 112;
            SENDRGB (  __context__ , (ushort)( 0 )) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object SAVEPRESET_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INDEX = 0;
        
        
        __context__.SourceCodeLine = 120;
        INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 121;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHOWTIMEFB  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 121;
            SHOWTIMEFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 121;
            CancelWait ( "SHOWTIMEWAIT" ) ; 
            } 
        
        __context__.SourceCodeLine = 122;
        _SplusNVRAM.PRESET [ INDEX] . SRED = (ushort) ( RED  .UshortValue ) ; 
        __context__.SourceCodeLine = 123;
        _SplusNVRAM.PRESET [ INDEX] . SGREEN = (ushort) ( GREEN  .UshortValue ) ; 
        __context__.SourceCodeLine = 124;
        _SplusNVRAM.PRESET [ INDEX] . SBLUE = (ushort) ( BLUE  .UshortValue ) ; 
        __context__.SourceCodeLine = 125;
        _SplusNVRAM.PRESET [ INDEX] . SFADE = (ushort) ( FADETIME  .UshortValue ) ; 
        __context__.SourceCodeLine = 126;
        _SplusNVRAM.PRESET [ INDEX] . ISUSED = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RECALLPRESET_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INDEX = 0;
        
        
        __context__.SourceCodeLine = 134;
        INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 135;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SHOWTIMEFB  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 135;
            SHOWTIMEFB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 135;
            CancelWait ( "SHOWTIMEWAIT" ) ; 
            } 
        
        __context__.SourceCodeLine = 136;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.PRESET[ INDEX ].ISUSED == 1))  ) ) 
            {
            __context__.SourceCodeLine = 136;
            EXEPRESET (  __context__ , (ushort)( INDEX ), (ushort)( 0 )) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 144;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 145;
        Functions.Delay (  (int) ( 500 ) ) ; 
        __context__.SourceCodeLine = 146;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)10; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 148;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.PRESET[ I ].SRED > 255 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.PRESET[ I ].SGREEN > 255 ) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.PRESET[ I ].SBLUE > 255 ) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.PRESET[ I ].SFADE > 255 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 150;
                _SplusNVRAM.PRESET [ I] . SRED = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 151;
                _SplusNVRAM.PRESET [ I] . SGREEN = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 152;
                _SplusNVRAM.PRESET [ I] . SBLUE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 153;
                _SplusNVRAM.PRESET [ I] . SFADE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 154;
                _SplusNVRAM.PRESET [ I] . ISUSED = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 146;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.PRESET  = new SPRESET[ 11 ];
    for( uint i = 0; i < 11; i++ )
    {
        _SplusNVRAM.PRESET [i] = new SPRESET( this, false );
        
    }
    
    SHOWTIME = new Crestron.Logos.SplusObjects.DigitalInput( SHOWTIME__DigitalInput__, this );
    m_DigitalInputList.Add( SHOWTIME__DigitalInput__, SHOWTIME );
    
    ALLOFF = new Crestron.Logos.SplusObjects.DigitalInput( ALLOFF__DigitalInput__, this );
    m_DigitalInputList.Add( ALLOFF__DigitalInput__, ALLOFF );
    
    ALLON = new Crestron.Logos.SplusObjects.DigitalInput( ALLON__DigitalInput__, this );
    m_DigitalInputList.Add( ALLON__DigitalInput__, ALLON );
    
    SLIDERRELEASE = new Crestron.Logos.SplusObjects.DigitalInput( SLIDERRELEASE__DigitalInput__, this );
    m_DigitalInputList.Add( SLIDERRELEASE__DigitalInput__, SLIDERRELEASE );
    
    RECALLPRESET = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        RECALLPRESET[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( RECALLPRESET__DigitalInput__ + i, RECALLPRESET__DigitalInput__, this );
        m_DigitalInputList.Add( RECALLPRESET__DigitalInput__ + i, RECALLPRESET[i+1] );
    }
    
    SAVEPRESET = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        SAVEPRESET[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SAVEPRESET__DigitalInput__ + i, SAVEPRESET__DigitalInput__, this );
        m_DigitalInputList.Add( SAVEPRESET__DigitalInput__ + i, SAVEPRESET[i+1] );
    }
    
    SHOWTIMEFB = new Crestron.Logos.SplusObjects.DigitalOutput( SHOWTIMEFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SHOWTIMEFB__DigitalOutput__, SHOWTIMEFB );
    
    RED = new Crestron.Logos.SplusObjects.AnalogInput( RED__AnalogSerialInput__, this );
    m_AnalogInputList.Add( RED__AnalogSerialInput__, RED );
    
    GREEN = new Crestron.Logos.SplusObjects.AnalogInput( GREEN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( GREEN__AnalogSerialInput__, GREEN );
    
    BLUE = new Crestron.Logos.SplusObjects.AnalogInput( BLUE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( BLUE__AnalogSerialInput__, BLUE );
    
    FADETIME = new Crestron.Logos.SplusObjects.AnalogInput( FADETIME__AnalogSerialInput__, this );
    m_AnalogInputList.Add( FADETIME__AnalogSerialInput__, FADETIME );
    
    REDFB = new Crestron.Logos.SplusObjects.AnalogOutput( REDFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( REDFB__AnalogSerialOutput__, REDFB );
    
    GREENFB = new Crestron.Logos.SplusObjects.AnalogOutput( GREENFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( GREENFB__AnalogSerialOutput__, GREENFB );
    
    BLUEFB = new Crestron.Logos.SplusObjects.AnalogOutput( BLUEFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( BLUEFB__AnalogSerialOutput__, BLUEFB );
    
    FADETIMEFB = new Crestron.Logos.SplusObjects.AnalogOutput( FADETIMEFB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( FADETIMEFB__AnalogSerialOutput__, FADETIMEFB );
    
    TODMX = new Crestron.Logos.SplusObjects.StringOutput( TODMX__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TODMX__AnalogSerialOutput__, TODMX );
    
    FADETIMETEXT = new Crestron.Logos.SplusObjects.StringOutput( FADETIMETEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FADETIMETEXT__AnalogSerialOutput__, FADETIMETEXT );
    
    DMXID = new UShortParameter( DMXID__Parameter__, this );
    m_ParameterList.Add( DMXID__Parameter__, DMXID );
    
    __SPLS_TMPVAR__WAITLABEL_0___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_0___CallbackFn );
    SHOWTIMEWAIT_Callback = new WaitFunction( SHOWTIMEWAIT_CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_1___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_1___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_2___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_2___CallbackFn );
    __SPLS_TMPVAR__WAITLABEL_3___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_3___CallbackFn );
    
    FADETIME.OnAnalogChange.Add( new InputChangeHandlerWrapper( FADETIME_OnChange_0, false ) );
    SHOWTIME.OnDigitalPush.Add( new InputChangeHandlerWrapper( SHOWTIME_OnPush_1, false ) );
    SLIDERRELEASE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SLIDERRELEASE_OnRelease_2, false ) );
    ALLON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLON_OnPush_3, false ) );
    ALLOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLOFF_OnPush_4, false ) );
    for( uint i = 0; i < 10; i++ )
        SAVEPRESET[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( SAVEPRESET_OnChange_5, false ) );
        
    for( uint i = 0; i < 10; i++ )
        RECALLPRESET[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( RECALLPRESET_OnChange_6, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_ENGINEERING_SOLUTIONS_DMX ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_0___Callback;
private WaitFunction SHOWTIMEWAIT_Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_1___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_2___Callback;
private WaitFunction __SPLS_TMPVAR__WAITLABEL_3___Callback;


const uint SHOWTIME__DigitalInput__ = 0;
const uint ALLOFF__DigitalInput__ = 1;
const uint ALLON__DigitalInput__ = 2;
const uint SLIDERRELEASE__DigitalInput__ = 3;
const uint RECALLPRESET__DigitalInput__ = 4;
const uint SAVEPRESET__DigitalInput__ = 14;
const uint RED__AnalogSerialInput__ = 0;
const uint GREEN__AnalogSerialInput__ = 1;
const uint BLUE__AnalogSerialInput__ = 2;
const uint FADETIME__AnalogSerialInput__ = 3;
const uint SHOWTIMEFB__DigitalOutput__ = 0;
const uint REDFB__AnalogSerialOutput__ = 0;
const uint GREENFB__AnalogSerialOutput__ = 1;
const uint BLUEFB__AnalogSerialOutput__ = 2;
const uint FADETIMEFB__AnalogSerialOutput__ = 3;
const uint TODMX__AnalogSerialOutput__ = 4;
const uint FADETIMETEXT__AnalogSerialOutput__ = 5;
const uint DMXID__Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, true, true)]
            public SPRESET [] PRESET;
            
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

[SplusStructAttribute(-1, true, false)]
public class SPRESET : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  SRED = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  SGREEN = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  SBLUE = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  SFADE = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  ISUSED = 0;
    
    
    public SPRESET( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        
        
    }
    
}

}
