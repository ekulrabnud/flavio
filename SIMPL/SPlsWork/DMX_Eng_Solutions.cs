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

namespace UserModule_DMX_ENG_SOLUTIONS
{
    public class UserModuleClass_DMX_ENG_SOLUTIONS : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.AnalogInput LEVEL;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        object LEVEL_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString TEMP;
                TEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
                
                
                __context__.SourceCodeLine = 181;
                TEMP  .UpdateValue ( Functions.ItoA (  (int) ( LEVEL  .UshortValue ) )  ) ; 
                __context__.SourceCodeLine = 182;
                MakeString ( TX__DOLLAR__ , "F001@{0}:000", TEMP ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        SocketInfo __socketinfo__ = new SocketInfo( 1, this );
        InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
        _SplusNVRAM = new SplusNVRAM( this );
        
        LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( LEVEL__AnalogSerialInput__, this );
        m_AnalogInputList.Add( LEVEL__AnalogSerialInput__, LEVEL );
        
        TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
        
        
        LEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( LEVEL_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_DMX_ENG_SOLUTIONS ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint LEVEL__AnalogSerialInput__ = 0;
    const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
    
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
