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

namespace UserModule_ML_GATEWAY_MK2_DECODE_FEEDBACK_0_0_7
{
    public class UserModuleClass_ML_GATEWAY_MK2_DECODE_FEEDBACK_0_0_7 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.StringInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogInput MLN_AUDIO_MASTER;
        Crestron.Logos.SplusObjects.AnalogInput MLN_BEOPORT;
        Crestron.Logos.SplusObjects.AnalogInput MLN_PRODUCT;
        Crestron.Logos.SplusObjects.DigitalInput AUDIO_SELECTED;
        Crestron.Logos.SplusObjects.DigitalInput BEOPORT_SELECTED;
        Crestron.Logos.SplusObjects.DigitalInput PRODUCT_SELECTED;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCE;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCE_CHAPTER;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCE_CHANNEL;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCE_DISC;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCE_DISC_TRACK;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCE_GROUP;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCE_AUDIO_TRACK;
        Crestron.Logos.SplusObjects.AnalogOutput SOURCE_ACTIVITY;
        Crestron.Logos.SplusObjects.AnalogOutput PICTURE_FORMAT;
        Crestron.Logos.SplusObjects.AnalogOutput SOUND_STATUS;
        Crestron.Logos.SplusObjects.AnalogOutput SPEAKER_MODE;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME_LEVEL;
        Crestron.Logos.SplusObjects.DigitalOutput SOUND_MUTE;
        Crestron.Logos.SplusObjects.DigitalOutput STEREO_DETECTED;
        Crestron.Logos.SplusObjects.DigitalOutput SCREEN_1_MUTE;
        Crestron.Logos.SplusObjects.DigitalOutput SCREEN_1_ACTIVE;
        Crestron.Logos.SplusObjects.DigitalOutput SCREEN_2_MUTE;
        Crestron.Logos.SplusObjects.DigitalOutput SCREEN_2_ACTIVE;
        Crestron.Logos.SplusObjects.DigitalOutput CINEMA_MODE_ON;
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        object RX__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 124;
                
                __context__.SourceCodeLine = 131;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (AUDIO_SELECTED  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 5 ) ) == MLN_AUDIO_MASTER  .UshortValue) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 2 ) ) == 2) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 3 ) ) == 8) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 138;
                    
                    __context__.SourceCodeLine = 142;
                    SOURCE_DISC  .Value = (ushort) ( ((Byte( RX__DOLLAR__ , (int)( 7 ) ) << 8) | Byte( RX__DOLLAR__ , (int)( (7 + 1) ) )) ) ; 
                    __context__.SourceCodeLine = 144;
                    SOURCE_DISC_TRACK  .Value = (ushort) ( ((Byte( RX__DOLLAR__ , (int)( 9 ) ) << 8) | Byte( RX__DOLLAR__ , (int)( (9 + 1) ) )) ) ; 
                    __context__.SourceCodeLine = 146;
                    SOURCE_ACTIVITY  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 11 ) ) ) ; 
                    __context__.SourceCodeLine = 147;
                    SOURCE  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 6 ) ) ) ; 
                    __context__.SourceCodeLine = 148;
                    PICTURE_FORMAT  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 12 ) ) ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 153;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (BEOPORT_SELECTED  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 5 ) ) == MLN_BEOPORT  .UshortValue) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 2 ) ) == 2) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 3 ) ) == 8) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 161;
                        
                        __context__.SourceCodeLine = 165;
                        SOURCE_GROUP  .Value = (ushort) ( ((Byte( RX__DOLLAR__ , (int)( 7 ) ) << 8) | Byte( RX__DOLLAR__ , (int)( (7 + 1) ) )) ) ; 
                        __context__.SourceCodeLine = 167;
                        SOURCE_AUDIO_TRACK  .Value = (ushort) ( ((Byte( RX__DOLLAR__ , (int)( 9 ) ) << 8) | Byte( RX__DOLLAR__ , (int)( (9 + 1) ) )) ) ; 
                        __context__.SourceCodeLine = 169;
                        SOURCE_ACTIVITY  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 11 ) ) ) ; 
                        __context__.SourceCodeLine = 170;
                        SOURCE  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 6 ) ) ) ; 
                        __context__.SourceCodeLine = 171;
                        PICTURE_FORMAT  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 12 ) ) ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 176;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (PRODUCT_SELECTED  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 5 ) ) == MLN_PRODUCT  .UshortValue) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 2 ) ) == 2) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 3 ) ) == 8) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 184;
                            
                            __context__.SourceCodeLine = 188;
                            SOURCE_CHAPTER  .Value = (ushort) ( ((Byte( RX__DOLLAR__ , (int)( 7 ) ) << 8) | Byte( RX__DOLLAR__ , (int)( (7 + 1) ) )) ) ; 
                            __context__.SourceCodeLine = 190;
                            SOURCE_CHANNEL  .Value = (ushort) ( ((Byte( RX__DOLLAR__ , (int)( 9 ) ) << 8) | Byte( RX__DOLLAR__ , (int)( (9 + 1) ) )) ) ; 
                            __context__.SourceCodeLine = 192;
                            SOURCE_ACTIVITY  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 11 ) ) ) ; 
                            __context__.SourceCodeLine = 193;
                            SOURCE  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 6 ) ) ) ; 
                            __context__.SourceCodeLine = 194;
                            PICTURE_FORMAT  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 12 ) ) ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 200;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 5 ) ) == MLN_PRODUCT  .UshortValue) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 2 ) ) == 3) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( RX__DOLLAR__ , (int)( 3 ) ) == 10) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 208;
                                
                                __context__.SourceCodeLine = 212;
                                SOUND_MUTE  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 6 ) ) ) ; 
                                __context__.SourceCodeLine = 213;
                                SOUND_STATUS  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 6 ) ) ) ; 
                                __context__.SourceCodeLine = 214;
                                SPEAKER_MODE  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 7 ) ) ) ; 
                                __context__.SourceCodeLine = 215;
                                VOLUME_LEVEL  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 8 ) ) ) ; 
                                __context__.SourceCodeLine = 216;
                                SCREEN_1_MUTE  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 9 ) ) ) ; 
                                __context__.SourceCodeLine = 217;
                                SCREEN_1_ACTIVE  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 10 ) ) ) ; 
                                __context__.SourceCodeLine = 218;
                                SCREEN_2_MUTE  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 11 ) ) ) ; 
                                __context__.SourceCodeLine = 219;
                                SCREEN_2_ACTIVE  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 12 ) ) ) ; 
                                __context__.SourceCodeLine = 220;
                                CINEMA_MODE_ON  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 13 ) ) ) ; 
                                __context__.SourceCodeLine = 221;
                                STEREO_DETECTED  .Value = (ushort) ( Byte( RX__DOLLAR__ , (int)( 14 ) ) ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 233;
                                
                                } 
                            
                            }
                        
                        }
                    
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
            
            __context__.SourceCodeLine = 251;
            WaitForInitializationComplete ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        AUDIO_SELECTED = new Crestron.Logos.SplusObjects.DigitalInput( AUDIO_SELECTED__DigitalInput__, this );
        m_DigitalInputList.Add( AUDIO_SELECTED__DigitalInput__, AUDIO_SELECTED );
        
        BEOPORT_SELECTED = new Crestron.Logos.SplusObjects.DigitalInput( BEOPORT_SELECTED__DigitalInput__, this );
        m_DigitalInputList.Add( BEOPORT_SELECTED__DigitalInput__, BEOPORT_SELECTED );
        
        PRODUCT_SELECTED = new Crestron.Logos.SplusObjects.DigitalInput( PRODUCT_SELECTED__DigitalInput__, this );
        m_DigitalInputList.Add( PRODUCT_SELECTED__DigitalInput__, PRODUCT_SELECTED );
        
        SOUND_MUTE = new Crestron.Logos.SplusObjects.DigitalOutput( SOUND_MUTE__DigitalOutput__, this );
        m_DigitalOutputList.Add( SOUND_MUTE__DigitalOutput__, SOUND_MUTE );
        
        STEREO_DETECTED = new Crestron.Logos.SplusObjects.DigitalOutput( STEREO_DETECTED__DigitalOutput__, this );
        m_DigitalOutputList.Add( STEREO_DETECTED__DigitalOutput__, STEREO_DETECTED );
        
        SCREEN_1_MUTE = new Crestron.Logos.SplusObjects.DigitalOutput( SCREEN_1_MUTE__DigitalOutput__, this );
        m_DigitalOutputList.Add( SCREEN_1_MUTE__DigitalOutput__, SCREEN_1_MUTE );
        
        SCREEN_1_ACTIVE = new Crestron.Logos.SplusObjects.DigitalOutput( SCREEN_1_ACTIVE__DigitalOutput__, this );
        m_DigitalOutputList.Add( SCREEN_1_ACTIVE__DigitalOutput__, SCREEN_1_ACTIVE );
        
        SCREEN_2_MUTE = new Crestron.Logos.SplusObjects.DigitalOutput( SCREEN_2_MUTE__DigitalOutput__, this );
        m_DigitalOutputList.Add( SCREEN_2_MUTE__DigitalOutput__, SCREEN_2_MUTE );
        
        SCREEN_2_ACTIVE = new Crestron.Logos.SplusObjects.DigitalOutput( SCREEN_2_ACTIVE__DigitalOutput__, this );
        m_DigitalOutputList.Add( SCREEN_2_ACTIVE__DigitalOutput__, SCREEN_2_ACTIVE );
        
        CINEMA_MODE_ON = new Crestron.Logos.SplusObjects.DigitalOutput( CINEMA_MODE_ON__DigitalOutput__, this );
        m_DigitalOutputList.Add( CINEMA_MODE_ON__DigitalOutput__, CINEMA_MODE_ON );
        
        MLN_AUDIO_MASTER = new Crestron.Logos.SplusObjects.AnalogInput( MLN_AUDIO_MASTER__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MLN_AUDIO_MASTER__AnalogSerialInput__, MLN_AUDIO_MASTER );
        
        MLN_BEOPORT = new Crestron.Logos.SplusObjects.AnalogInput( MLN_BEOPORT__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MLN_BEOPORT__AnalogSerialInput__, MLN_BEOPORT );
        
        MLN_PRODUCT = new Crestron.Logos.SplusObjects.AnalogInput( MLN_PRODUCT__AnalogSerialInput__, this );
        m_AnalogInputList.Add( MLN_PRODUCT__AnalogSerialInput__, MLN_PRODUCT );
        
        SOURCE = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCE__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SOURCE__AnalogSerialOutput__, SOURCE );
        
        SOURCE_CHAPTER = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCE_CHAPTER__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SOURCE_CHAPTER__AnalogSerialOutput__, SOURCE_CHAPTER );
        
        SOURCE_CHANNEL = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCE_CHANNEL__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SOURCE_CHANNEL__AnalogSerialOutput__, SOURCE_CHANNEL );
        
        SOURCE_DISC = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCE_DISC__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SOURCE_DISC__AnalogSerialOutput__, SOURCE_DISC );
        
        SOURCE_DISC_TRACK = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCE_DISC_TRACK__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SOURCE_DISC_TRACK__AnalogSerialOutput__, SOURCE_DISC_TRACK );
        
        SOURCE_GROUP = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCE_GROUP__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SOURCE_GROUP__AnalogSerialOutput__, SOURCE_GROUP );
        
        SOURCE_AUDIO_TRACK = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCE_AUDIO_TRACK__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SOURCE_AUDIO_TRACK__AnalogSerialOutput__, SOURCE_AUDIO_TRACK );
        
        SOURCE_ACTIVITY = new Crestron.Logos.SplusObjects.AnalogOutput( SOURCE_ACTIVITY__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SOURCE_ACTIVITY__AnalogSerialOutput__, SOURCE_ACTIVITY );
        
        PICTURE_FORMAT = new Crestron.Logos.SplusObjects.AnalogOutput( PICTURE_FORMAT__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( PICTURE_FORMAT__AnalogSerialOutput__, PICTURE_FORMAT );
        
        SOUND_STATUS = new Crestron.Logos.SplusObjects.AnalogOutput( SOUND_STATUS__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SOUND_STATUS__AnalogSerialOutput__, SOUND_STATUS );
        
        SPEAKER_MODE = new Crestron.Logos.SplusObjects.AnalogOutput( SPEAKER_MODE__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( SPEAKER_MODE__AnalogSerialOutput__, SPEAKER_MODE );
        
        VOLUME_LEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_LEVEL__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( VOLUME_LEVEL__AnalogSerialOutput__, VOLUME_LEVEL );
        
        RX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( RX__DOLLAR____AnalogSerialInput__, 40, this );
        m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
        
        
        RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_ML_GATEWAY_MK2_DECODE_FEEDBACK_0_0_7 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint RX__DOLLAR____AnalogSerialInput__ = 0;
    const uint MLN_AUDIO_MASTER__AnalogSerialInput__ = 1;
    const uint MLN_BEOPORT__AnalogSerialInput__ = 2;
    const uint MLN_PRODUCT__AnalogSerialInput__ = 3;
    const uint AUDIO_SELECTED__DigitalInput__ = 0;
    const uint BEOPORT_SELECTED__DigitalInput__ = 1;
    const uint PRODUCT_SELECTED__DigitalInput__ = 2;
    const uint SOURCE__AnalogSerialOutput__ = 0;
    const uint SOURCE_CHAPTER__AnalogSerialOutput__ = 1;
    const uint SOURCE_CHANNEL__AnalogSerialOutput__ = 2;
    const uint SOURCE_DISC__AnalogSerialOutput__ = 3;
    const uint SOURCE_DISC_TRACK__AnalogSerialOutput__ = 4;
    const uint SOURCE_GROUP__AnalogSerialOutput__ = 5;
    const uint SOURCE_AUDIO_TRACK__AnalogSerialOutput__ = 6;
    const uint SOURCE_ACTIVITY__AnalogSerialOutput__ = 7;
    const uint PICTURE_FORMAT__AnalogSerialOutput__ = 8;
    const uint SOUND_STATUS__AnalogSerialOutput__ = 9;
    const uint SPEAKER_MODE__AnalogSerialOutput__ = 10;
    const uint VOLUME_LEVEL__AnalogSerialOutput__ = 11;
    const uint SOUND_MUTE__DigitalOutput__ = 0;
    const uint STEREO_DETECTED__DigitalOutput__ = 1;
    const uint SCREEN_1_MUTE__DigitalOutput__ = 2;
    const uint SCREEN_1_ACTIVE__DigitalOutput__ = 3;
    const uint SCREEN_2_MUTE__DigitalOutput__ = 4;
    const uint SCREEN_2_ACTIVE__DigitalOutput__ = 5;
    const uint CINEMA_MODE_ON__DigitalOutput__ = 6;
    
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
