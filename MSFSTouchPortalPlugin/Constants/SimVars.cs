﻿using MSFSTouchPortalPlugin.Attributes;
using System;

namespace MSFSTouchPortalPlugin.Constants {
  public enum Definition {
    Init = 0,
    AileronTrimPct,
    AutoPilotPitchHold,
    GroundVelocity,
    LaunchBarPosition,
    LightBeaconOn,
    LightBrakeOn,
    LightCabinOn,
    LightHeadOn,
    LightLandingOn,
    LightLogoOn,
    LightNavOn,
    LightPanelOn,
    LightRecognitionOn,
    LightStrobeOn,
    LightTaxiOn,
    LightWingOn,
    MasterIgnitionSwitch,
    RudderTrimPct
  }

  public enum Request {
    Init = 0,
    AileronTrimPct,
    AutoPilotPitchHold,
    GroundVelocity,
    LaunchBarPosition,
    LightBeaconOn,
    LightBrakeOn,
    LightCabinOn,
    LightHeadOn,
    LightLandingOn,
    LightLogoOn,
    LightNavOn,
    LightPanelOn,
    LightRecognitionOn,
    LightStrobeOn,
    LightTaxiOn,
    LightWingOn,
    MasterIgnitionSwitch,
    RudderTrimPct
  }

  public static class SimVars {

    #region AutoPilot

    [SimVarDataRequest]
    public static SimVarItem AutoPilotPitchHold = new SimVarItem() { def = Definition.AutoPilotPitchHold, req = Request.AutoPilotPitchHold, SimVarName = "AUTOPILOT PITCH HOLD", Unit = Units.Bool, CanSet = false };

    #endregion

    #region Engine Systems

    [SimVarDataRequest]
    public static SimVarItem MasterIgnitionSwitch = new SimVarItem() { def = Definition.MasterIgnitionSwitch, req = Request.MasterIgnitionSwitch, SimVarName = "MASTER IGNITION SWITCH", Unit = Units.Bool, CanSet = false };

    #endregion

    #region Flight Systems

    [SimVarDataRequest] // XYZ
    public static SimVarItem AileronTrimPct = new SimVarItem() { def = Definition.AileronTrimPct, req = Request.AileronTrimPct, SimVarName = "", Unit = Units.number, CanSet = true };
    [SimVarDataRequest]
    public static SimVarItem RudderTrimPct = new SimVarItem() { def = Definition.RudderTrimPct, req = Request.RudderTrimPct, SimVarName = "RUDDER TRIM PCT", Unit = Units.percentover100, CanSet = true };

    #endregion

    #region Fuel Systems
    #endregion

    [SimVarDataRequest]
    public static SimVarItem LaunchBarPosition = new SimVarItem() { def = Definition.LaunchBarPosition, req = Request.LaunchBarPosition, SimVarName = "LAUNCHBAR POSITION", Unit = Units.percentover100, CanSet = false };

    #region Lights

    [SimVarDataRequest]
    public static SimVarItem LightBeaconOn = new SimVarItem() { def = Definition.LightBeaconOn, req = Request.LightBeaconOn, SimVarName = "LIGHT BEACON ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightBrakeOn = new SimVarItem() { def = Definition.LightBrakeOn, req = Request.LightBrakeOn, SimVarName = "LIGHT BRAKE ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightCabinOn = new SimVarItem() { def = Definition.LightCabinOn, req = Request.LightCabinOn, SimVarName = "LIGHT CABIN ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightHeadOn = new SimVarItem() { def = Definition.LightHeadOn, req = Request.LightHeadOn, SimVarName = "LIGHT HEAD ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightLandingOn = new SimVarItem() { def = Definition.LightLandingOn, req = Request.LightLandingOn, SimVarName = "LIGHT LANDING ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightLogoOn = new SimVarItem() { def = Definition.LightLogoOn, req = Request.LightLogoOn, SimVarName = "LIGHT LOGO ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightNavOn = new SimVarItem() { def = Definition.LightNavOn, req = Request.LightNavOn, SimVarName = "LIGHT NAV ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightPanelOn = new SimVarItem() { def = Definition.LightPanelOn, req = Request.LightPanelOn, SimVarName = "LIGHT PANEL ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightRecognitionOn = new SimVarItem() { def = Definition.LightRecognitionOn, req = Request.LightRecognitionOn, SimVarName = "LIGHT RECOGNITION ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightStrobeOn = new SimVarItem() { def = Definition.LightStrobeOn, req = Request.LightStrobeOn, SimVarName = "LIGHT STROBE ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightTaxiOn = new SimVarItem() { def = Definition.LightTaxiOn, req = Request.LightTaxiOn, SimVarName = "LIGHT TAXI ON", Unit = Units.Bool, CanSet = false };
    [SimVarDataRequest]
    public static SimVarItem LightWingOn = new SimVarItem() { def = Definition.LightWingOn, req = Request.LightWingOn, SimVarName = "LIGHT WING ON", Unit = Units.Bool, CanSet = false };

    #endregion

    #region Measurements

    [SimVarDataRequest]
    public static SimVarItem GroundVelocity = new SimVarItem() { def = Definition.GroundVelocity, req = Request.GroundVelocity, SimVarName = "GROUND VELOCITY", Unit = Units.feet, CanSet = false };

    #endregion

  }

  public class SimVarItem {
    public Definition def;
    public Request req;
    public string SimVarName;
    public string Unit;
    public bool CanSet = false;
    public bool PendingRequest = false;
    public DateTime LastPending = DateTime.Now;
    public string TouchPortalStateMapping;

    public void SetPending(bool val) {
      PendingRequest = val;

      if (val) {
        LastPending = DateTime.Now;
      }
    }

    /// <summary>
    /// If pending for more than 30 seconds, timeout
    /// </summary>
    public void PendingTimeout() {
      if (PendingRequest) {
        if (DateTime.Now > LastPending.AddSeconds(30)) {
          SetPending(false);
        }
      }
    }
  }
}