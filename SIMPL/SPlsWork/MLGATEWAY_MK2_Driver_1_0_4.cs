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

namespace UserModule_MLGATEWAY_MK2_DRIVER_1_0_4
{
    public class UserModuleClass_MLGATEWAY_MK2_DRIVER_1_0_4 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput LOGIN_REQUIRED;
        Crestron.Logos.SplusObjects.AnalogInput VIRTUAL_BUTTON;
        Crestron.Logos.SplusObjects.BufferInput COMM_RX__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput OUTGOING_MSG;
        Crestron.Logos.SplusObjects.DigitalOutput LOGIN_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ALL_STANDBY_FB;
        Crestron.Logos.SplusObjects.StringOutput COMM_TX__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput INCOMING_MSG;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> LIGHT_STATUS_RM;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CONTROL_STATUS_RM;
        StringParameter LOGIN;
        StringParameter PASSWORD;
        
        
        
        
        
        
        
        
        
        
        
        private void LOG_ME_IN (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 188;
            MakeString ( COMM_TX__DOLLAR__ , "\u0001\u0030{0}\u0000{1}\u0000{2}", Functions.Chr (  (int) ( ((Functions.Length( LOGIN  ) + Functions.Length( PASSWORD  )) + 1) ) ) , LOGIN , PASSWORD ) ; 
            
            }
            
        private void SEND_PACKAGE (  SplusExecutionContext __context__ ) 
            { 
            CrestronString TEMPORAL;
            TEMPORAL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            
            ushort I = 0;
            
            ushort LOGGING_IN = 0;
            
            
            __context__.SourceCodeLine = 199;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)(_SplusNVRAM.BUFF_INDEX - 1); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 201;
                MakeString ( TEMPORAL , "{0}{1}", TEMPORAL , Functions.Chr ( _SplusNVRAM.BUFFER[ I ] ) ) ; 
                __context__.SourceCodeLine = 199;
                } 
            
            __context__.SourceCodeLine = 204;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 2 ) ) == 4) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 3 ) ) == 3) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 208;
                _SplusNVRAM.ROOM_NUMBER = (ushort) ( Byte( TEMPORAL , (int)( 5 ) ) ) ; 
                __context__.SourceCodeLine = 210;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 6 ) ) == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 211;
                    LIGHT_STATUS_RM [ _SplusNVRAM.ROOM_NUMBER]  .Value = (ushort) ( Byte( TEMPORAL , (int)( 7 ) ) ) ; 
                    }
                
                __context__.SourceCodeLine = 213;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 6 ) ) == 2))  ) ) 
                    {
                    __context__.SourceCodeLine = 214;
                    CONTROL_STATUS_RM [ _SplusNVRAM.ROOM_NUMBER]  .Value = (ushort) ( Byte( TEMPORAL , (int)( 7 ) ) ) ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 218;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 2 ) ) == 5) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 3 ) ) == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 222;
                    Functions.Pulse ( 10, ALL_STANDBY_FB ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 226;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 2 ) ) == 49) ) && Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 3 ) ) == 1) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 230;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 5 ) ) == 0))  ) ) 
                            { 
                            __context__.SourceCodeLine = 232;
                            LOGIN_FB  .Value = (ushort) ( 1 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 235;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 5 ) ) == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 237;
                                LOGIN_FB  .Value = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 239;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOGIN_REQUIRED  .Value == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 241;
                                    LOG_ME_IN (  __context__  ) ; 
                                    } 
                                
                                } 
                            
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 249;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 2 ) ) == 2) ) || Functions.TestForTrue ( Functions.BoolToInt (Byte( TEMPORAL , (int)( 2 ) ) == 3) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 253;
                            INCOMING_MSG  .UpdateValue ( TEMPORAL  ) ; 
                            } 
                        
                        else 
                            { 
                            } 
                        
                        }
                    
                    }
                
                }
            
            
            }
            
        private void SEND_CMD (  SplusExecutionContext __context__ ) 
            { 
            CrestronString TEMP_CMD;
            TEMP_CMD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            
            ushort N = 0;
            
            
            __context__.SourceCodeLine = 271;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)(_SplusNVRAM.CMD_BUFF_INDEX - 1); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( N  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (N  >= __FN_FORSTART_VAL__1) && (N  <= __FN_FOREND_VAL__1) ) : ( (N  <= __FN_FORSTART_VAL__1) && (N  >= __FN_FOREND_VAL__1) ) ; N  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 273;
                MakeString ( TEMP_CMD , "{0}{1}", TEMP_CMD , Functions.Chr ( _SplusNVRAM.CMD_BUFFER[ N ] ) ) ; 
                __context__.SourceCodeLine = 271;
                } 
            
            __context__.SourceCodeLine = 275;
            COMM_TX__DOLLAR__  .UpdateValue ( TEMP_CMD  ) ; 
            
            }
            
        
        
        
        
        
        object VIRTUAL_BUTTON_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 293;
                MakeString ( COMM_TX__DOLLAR__ , "\u0001\u0020\u0001\u0000{0}", Functions.Chr (  (int) ( VIRTUAL_BUTTON  .UshortValue ) ) ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object COMM_RX__DOLLAR___OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 299;
            _SplusNVRAM.READ = (ushort) ( Functions.GetC( COMM_RX__DOLLAR__ ) ) ; 
            __context__.SourceCodeLine = 302;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (_SplusNVRAM.TIMER + 2) < Functions.GetSecondsNum() ))  ) ) 
                { 
                __context__.SourceCodeLine = 304;
                _SplusNVRAM.BUFF_INDEX = (ushort) ( 0 ) ; 
                } 
            
            __context__.SourceCodeLine = 307;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.READ != 65535))  ) ) 
                { 
                __context__.SourceCodeLine = 310;
                _SplusNVRAM.TIMER = (ushort) ( Functions.GetSecondsNum() ) ; 
                __context__.SourceCodeLine = 311;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.TIMER > (59 - 2) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 313;
                    _SplusNVRAM.TIMER = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 316;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.BUFF_INDEX == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.READ == 1) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.BUFF_INDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.BUFF_INDEX < 4 ) )) ) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.BUFF_INDEX >= 4 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.BUFF_INDEX < (_SplusNVRAM.BUFFER[ 2 ] + 4) ) )) ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 321;
                    _SplusNVRAM.BUFFER [ _SplusNVRAM.BUFF_INDEX] = (ushort) ( _SplusNVRAM.READ ) ; 
                    __context__.SourceCodeLine = 322;
                    _SplusNVRAM.BUFF_INDEX = (ushort) ( (_SplusNVRAM.BUFF_INDEX + 1) ) ; 
                    } 
                
                else 
                    { 
                    } 
                
                __context__.SourceCodeLine = 329;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.BUFF_INDEX >= 4 ) ) && Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.BUFF_INDEX == (_SplusNVRAM.BUFFER[ 2 ] + 4)) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 333;
                    SEND_PACKAGE (  __context__  ) ; 
                    __context__.SourceCodeLine = 335;
                    _SplusNVRAM.BUFF_INDEX = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 338;
                _SplusNVRAM.READ = (ushort) ( Functions.GetC( COMM_RX__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 307;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object OUTGOING_MSG_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 344;
        _SplusNVRAM.CMD_BUFF_INDEX = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 345;
        _SplusNVRAM.CMD_READ = (ushort) ( Functions.GetC( OUTGOING_MSG ) ) ; 
        __context__.SourceCodeLine = 346;
        while ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.CMD_READ != 65535))  ) ) 
            { 
            __context__.SourceCodeLine = 348;
            _SplusNVRAM.CMD_BUFFER [ _SplusNVRAM.CMD_BUFF_INDEX] = (ushort) ( _SplusNVRAM.CMD_READ ) ; 
            __context__.SourceCodeLine = 349;
            _SplusNVRAM.CMD_BUFF_INDEX = (ushort) ( (_SplusNVRAM.CMD_BUFF_INDEX + 1) ) ; 
            __context__.SourceCodeLine = 350;
            _SplusNVRAM.CMD_READ = (ushort) ( Functions.GetC( OUTGOING_MSG ) ) ; 
            __context__.SourceCodeLine = 346;
            } 
        
        __context__.SourceCodeLine = 352;
        SEND_CMD (  __context__  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 375;
        _SplusNVRAM.BUFF_INDEX = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 376;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 378;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (LOGIN_REQUIRED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 380;
            LOG_ME_IN (  __context__  ) ; 
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
    _SplusNVRAM.BUFFER  = new ushort[ 26 ];
    _SplusNVRAM.CMD_BUFFER  = new ushort[ 26 ];
    
    LOGIN_REQUIRED = new Crestron.Logos.SplusObjects.DigitalInput( LOGIN_REQUIRED__DigitalInput__, this );
    m_DigitalInputList.Add( LOGIN_REQUIRED__DigitalInput__, LOGIN_REQUIRED );
    
    LOGIN_FB = new Crestron.Logos.SplusObjects.DigitalOutput( LOGIN_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( LOGIN_FB__DigitalOutput__, LOGIN_FB );
    
    ALL_STANDBY_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ALL_STANDBY_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ALL_STANDBY_FB__DigitalOutput__, ALL_STANDBY_FB );
    
    VIRTUAL_BUTTON = new Crestron.Logos.SplusObjects.AnalogInput( VIRTUAL_BUTTON__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VIRTUAL_BUTTON__AnalogSerialInput__, VIRTUAL_BUTTON );
    
    LIGHT_STATUS_RM = new InOutArray<AnalogOutput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        LIGHT_STATUS_RM[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( LIGHT_STATUS_RM__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( LIGHT_STATUS_RM__AnalogSerialOutput__ + i, LIGHT_STATUS_RM[i+1] );
    }
    
    CONTROL_STATUS_RM = new InOutArray<AnalogOutput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        CONTROL_STATUS_RM[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CONTROL_STATUS_RM__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CONTROL_STATUS_RM__AnalogSerialOutput__ + i, CONTROL_STATUS_RM[i+1] );
    }
    
    COMM_TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( COMM_TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( COMM_TX__DOLLAR____AnalogSerialOutput__, COMM_TX__DOLLAR__ );
    
    INCOMING_MSG = new Crestron.Logos.SplusObjects.StringOutput( INCOMING_MSG__AnalogSerialOutput__, this );
    m_StringOutputList.Add( INCOMING_MSG__AnalogSerialOutput__, INCOMING_MSG );
    
    COMM_RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( COMM_RX__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( COMM_RX__DOLLAR____AnalogSerialInput__, COMM_RX__DOLLAR__ );
    
    OUTGOING_MSG = new Crestron.Logos.SplusObjects.BufferInput( OUTGOING_MSG__AnalogSerialInput__, 255, this );
    m_StringInputList.Add( OUTGOING_MSG__AnalogSerialInput__, OUTGOING_MSG );
    
    LOGIN = new StringParameter( LOGIN__Parameter__, this );
    m_ParameterList.Add( LOGIN__Parameter__, LOGIN );
    
    PASSWORD = new StringParameter( PASSWORD__Parameter__, this );
    m_ParameterList.Add( PASSWORD__Parameter__, PASSWORD );
    
    
    VIRTUAL_BUTTON.OnAnalogChange.Add( new InputChangeHandlerWrapper( VIRTUAL_BUTTON_OnChange_0, false ) );
    COMM_RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( COMM_RX__DOLLAR___OnChange_1, false ) );
    OUTGOING_MSG.OnSerialChange.Add( new InputChangeHandlerWrapper( OUTGOING_MSG_OnChange_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_MLGATEWAY_MK2_DRIVER_1_0_4 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint LOGIN_REQUIRED__DigitalInput__ = 0;
const uint VIRTUAL_BUTTON__AnalogSerialInput__ = 0;
const uint COMM_RX__DOLLAR____AnalogSerialInput__ = 1;
const uint OUTGOING_MSG__AnalogSerialInput__ = 2;
const uint LOGIN_FB__DigitalOutput__ = 0;
const uint ALL_STANDBY_FB__DigitalOutput__ = 1;
const uint COMM_TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint INCOMING_MSG__AnalogSerialOutput__ = 1;
const uint LIGHT_STATUS_RM__AnalogSerialOutput__ = 2;
const uint CONTROL_STATUS_RM__AnalogSerialOutput__ = 18;
const uint LOGIN__Parameter__ = 10;
const uint PASSWORD__Parameter__ = 11;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort BUFF_INDEX = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort [] BUFFER;
            [SplusStructAttribute(2, false, true)]
            public ushort CMD_BUFF_INDEX = 0;
            [SplusStructAttribute(3, false, true)]
            public ushort [] CMD_BUFFER;
            [SplusStructAttribute(4, false, true)]
            public ushort READ = 0;
            [SplusStructAttribute(5, false, true)]
            public ushort CMD_READ = 0;
            [SplusStructAttribute(6, false, true)]
            public ushort TIMER = 0;
            [SplusStructAttribute(7, false, true)]
            public ushort ROOM_NUMBER = 0;
            
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
