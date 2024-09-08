﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialPark
{
    public enum AnimTableStates : uint
    {
        Unknown = 0,
        AB_L_InAir = 0x95C1431C,
        AC_L_Point01 = 0xB8B0A969,
        ActionLaunchApex01 = 0x40FF2D14,
        ActionLaunchFall01 = 0x2433F265,
        ActionLaunchFling01 = 0x20E5C560,
        ActionLaunchGrab01 = 0x48A56536,
        ActionLaunchIdle01 = 0x4B682272,
        ActionLaunchIntro01 = 0xF7A85400,
        ActionLaunchLand01 = 0x09903A05,
        ActionLaunchLift01 = 0x94EFB045,
        ActionLiftDrop01 = 0xB3B5D925,
        ActionLiftGrab01 = 0xA45ED286,
        ActionLiftStruggle01 = 0xE200F49F,
        ActionLiftToss01 = 0x37DB6CE9,
        ActionTurnGrab01 = 0xCC787A98,
        ActionTurnIdle01 = 0xCF3B37D4,
        ActionTurnLeft01 = 0xD28BEC63,
        ActionTurnLToR01 = 0xDB0DCF83,
        ActionTurnRelease01 = 0x3AD85835,
        ActionTurnRIght01 = 0xF7D64B8A,
        ActionTurnRToL01 = 0xC02601FF,
        Active01 = 0x2FFE87AB,
        AL_L_Siren01 = 0x2BED1763,
        AlertIdle01 = 0xB72B79ED,
        AlertMove01 = 0x67AA8542,
        AM_L_Away01 = 0x7DFB7331,
        AngryArena = 0x5C38FA8A,
        Anim02 = 0x3FA1188B,
        Anim03 = 0x3FA1188C,
        Attack = 0xAA699980,
        attack_beam_begin = 0x5B7675B0,
        attack_beam_end = 0x1C2C3C42,
        attack_beam_loop = 0x6B933DFD,
        attack_bomb = 0xAFEBF5F5,
        Attack_Done = 0xB03091B1,
        Attack_Left = 0xB1405C26,
        Attack_Loop = 0xB142FF17,
        attack_missle = 0x56DA290C,
        Attack_Prep = 0xB1CCF980,
        Attack_Right = 0x1DCAE0FD,
        attack_wall_begin = 0xC47940EB,
        attack_wall_end = 0xD1DC1565,
        attack_wall_loop = 0x648F5AE6,
        Attack01 = 0xA0E2FE41,
        Attack02 = 0xA0E2FE42,
        Attack02End01 = 0x5C353DDA,
        Attack02Loop01 = 0x22EC237B,
        Attack02Windup01 = 0x239AA0B6,
        Attack03 = 0xA0E2FE43,
        Attack04 = 0xA0E2FE44,
        Attack1Done = 0x88B9CF23,
        Attack1Loop = 0x89CC3C89,
        Attack1Prep = 0x8A5636F2,
        Attack2 = 0x34098CB2,
        AttackBackThrust01 = 0x978AFB88,
        AttackBegin01 = 0xDE08539A,
        AttackButterfly01 = 0x9EBEBFC0,
        AttackCartwheel01 = 0x158EF42C,
        AttackChargeClap01 = 0x82866389,
        AttackChargeCrouch01 = 0x1A8892D7,
        AttackCrouch01 = 0xF00E4C1F,
        AttackCrouch02 = 0xF00E4C20,
        AttackCrouch03 = 0xF00E4C21,
        AttackCrouch04 = 0xF00E4C22,
        AttackCrouch05 = 0xF00E4C23,
        AttackEnd = 0x542DAA1B,
        AttackEnd01 = 0xE92024B4,
        AttackGolfSwing01 = 0x5A063CBD,
        AttackJumpFlip01 = 0x0A5BFFF4,
        AttackJumpKick01 = 0xBE793571,
        AttackJumpKickLand01 = 0x066E70C4,
        AttackJumpKickLandRun01 = 0x708AE0B9,
        AttackJumpLand01 = 0x2F074EC6,
        AttackJumpStomp01 = 0xBF3BFD5C,
        AttackKickBoth01 = 0xC7FC04A8,
        AttackKickLeft01 = 0xE9C0BDEE,
        AttackKickRight01 = 0xD7DD85AB,
        AttackKickRight02 = 0xD7DD85AC,
        AttackLoop = 0x144E7408,
        AttackLoop01 = 0x3F204509,
        AttackPunchLeft01 = 0xE0D6C436,
        AttackPunchLeft04 = 0xE0D6C439,
        AttackPunchLeft05 = 0xE0D6C43A,
        AttackPunchLeft07 = 0xE0D6C43C,
        AttackPunchLondLeftEnd01 = 0x348F09F6,
        AttackPunchLongLeftBegin01 = 0x6748695D,
        AttackPunchLongLeftExtend01 = 0x2906F3C8,
        AttackPunchLongLeftRetract01 = 0x494EB9C5,
        AttackPunchLongRightBegin01 = 0x0163205C,
        AttackPunchLongRightEnd01 = 0x942471E6,
        AttackPunchLongRightExtend01 = 0x04B29845,
        AttackPunchLongRightRetract01 = 0xB223E5BC,
        AttackPunchRight01 = 0x4822BC83,
        AttackPunchRight03 = 0x4822BC85,
        AttackPunchRight05 = 0x4822BC87,
        AttackPunchRight11 = 0x4822BD06,
        AttackPunchRight12 = 0x4822BD07,
        AttackPunchRight13 = 0x4822BD08,
        AttackPunchRight14 = 0x4822BD09,
        AttackPunchRight15 = 0x4822BD0A,
        AttackRam02 = 0xCB96D144,
        AttackRamBegin01 = 0x7EA9B380,
        AttackRamEnd01 = 0xE0BC80EA,
        AttackRamLoop01 = 0xF42374AB,
        AttackRumble = 0x8D441855,
        AttackRun01 = 0xCE452468,
        AttackSlam01 = 0xE9342AA6,
        AttackSlamFall01 = 0x23BE6CE9,
        AttackSlamFall02 = 0x23BE6CEA,
        AttackSlamFall03 = 0x23BE6CEB,
        AttackSlamFall04 = 0x23BE6CEC,
        AttackSlamFall05 = 0x23BE6CED,
        AttackSlamLand01 = 0x091AB489,
        AttackSlamLand02 = 0x091AB48A,
        AttackStart = 0xDFAD3732,
        AttackStomp = 0xDFB0DF1D,
        AttackSuperSpinEnd01 = 0xD6C5E2E3,
        AttackSuperSpinEnd02 = 0xD6C5E2E4,
        AttackSuperSpinEnd03 = 0xD6C5E2E5,
        AttackSuperSpinEnd04 = 0xD6C5E2E6,
        AttackSuperSpinEnd05 = 0xD6C5E2E7,
        AttackSuperSpinIntro01 = 0x479279D4,
        AttackSuperSpinIntro02 = 0x479279D5,
        AttackSuperSpinLoop01 = 0xDAF09716,
        AttackSuperSpinLoop02 = 0xDAF09717,
        AttackSuperSpinLoop03 = 0xDAF09718,
        AttackSuperSpinLoop04 = 0xDAF09719,
        AttackSuperSpinLoop05 = 0xDAF0971A,
        AttackWheelIntro01 = 0x78D711DA,
        AttackWheelIntro02 = 0x78D711DB,
        AttackWheelLoop01 = 0x7F77F418,
        AttackWheelOutro01 = 0x95A4C915,
        AttackWheelOutro02 = 0x95A4C916,
        AttackWindup01 = 0xC637F8B4,
        AwayKnockback = 0x9EC23675,
        BA_L_AttackPause01 = 0x954E488C,
        BA_L_Cycle01 = 0xC64E4D68,
        BA_L_WalkBackwards01 = 0xE064F5F1,
        BA_S_ShootDone01 = 0xFD8D39C2,
        BA_T_BeginAttack01 = 0x0A3A7A2F,
        BA_T_Hit01 = 0xE3E7300D,
        BA_T_Shoot01 = 0xF9489781,
        BALL_BEGIN = 0xF7E63995,
        BALL_END = 0x97BAA13F,
        BALL_LOOP = 0xA570EB74,
        BbashAttack01 = 0x126DE863,
        BbashMiss01 = 0xB928A42F,
        BbashStart01 = 0x8E9B36B9,
        BbashStrike01 = 0x0E0B5F6D,
        BbounceAttack01 = 0x5C6BB0DB,
        BbounceStart01 = 0xE91072E1,
        BbounceStrike01 = 0x580927E5,
        Bbowl01 = 0xE49F43B1,
        BbowlRecover01 = 0xC131B6C1,
        BbowlStart01 = 0x663420D3,
        BbowlToss01 = 0x126C3898,
        BbowlWindup01 = 0x36B9A4A4,
        BEATIT = 0x9C197079,
        BI_L_Idle01 = 0x25876FD8,
        BITCH_SLAP = 0x876355BD,
        BJ_L_Fall01 = 0xD229E12E,
        BJ_L_Start01 = 0xA3122731,
        BJ_T_Land01 = 0x72B42926,
        BK_L_Slow = 0xB99B5326,
        BL_L_BlockCycle01 = 0x03531C76,
        BL_L_BlockHit01 = 0x76E0A563,
        BL_L_BlockHit02 = 0x76E0A564,
        BL_L_BlockHit03 = 0x76E0A565,
        BL_L_Pivot01 = 0xF42D4CDB,
        BL_T_Lob01 = 0x3EA5223C,
        BombLeft_Done = 0x522A2378,
        BombLeft_Loop = 0x533C90DE,
        BombLeft_Prep = 0x53C68B47,
        BombRight_Done = 0x6FAD65F7,
        BombRight_Loop = 0x70BFD35D,
        BombRight_Prep = 0x7149CDC6,
        BOOMERANG_CATCH_BEGIN = 0x881EBA08,
        BOOMERANG_CATCH_END = 0x2233BBDA,
        BOOMERANG_CATCH_LOOP = 0x816988C5,
        BOOMERANG_SHOOT_BEGIN = 0x541470D8,
        BOOMERANG_SHOOT_END = 0x0C6B602A,
        BOOMERANG_SHOOT_LOOP = 0x5BE29DB5,
        Boosting = 0xE573BC2B,
        BoulderRoll01 = 0x7033D81B,
        BoulderRoll02 = 0x7033D81C,
        BounceApex01 = 0xFAD2FA4B,
        BounceLift01 = 0x4EC37D7C,
        BounceStart01 = 0xB59AF97B,
        BS_L_Sleep01 = 0xA8E0EACB,
        Bspin01 = 0xA816443D,
        Bspin02 = 0xA816443E,
        BU_L_Wait01 = 0x9FC70289,
        BU_T_Alert01 = 0x8C444AE6,
        BuddyZip01 = 0x4D37A2C4,
        BuddyZipHit01 = 0xC342F681,
        Bump01 = 0xB68F5FBB,
        Bumped01 = 0xF3EDBEB6,
        bungee_bottom_0 = 0xC11A12BB,
        bungee_cycle_0 = 0x177EE824,
        bungee_death_0 = 0x03D36852,
        bungee_dive_0 = 0x52D02EC0,
        bungee_hit_0 = 0xC5DE1281,
        bungee_mount_0 = 0x8F8D668F,
        bungee_top_0 = 0x994F63CB,
        ButtSlide01 = 0x8BE6B9D3,
        CA_L_Attack01 = 0x36E23269,
        CA_L_CarryIdle01 = 0xB97DE6A0,
        CA_L_CarryThrowLoop02 = 0x7F0D8479,
        CA_L_CarryWalk01 = 0x4612762D,
        CA_L_Fall = 0x26F24483,
        CA_L_Lift = 0x27C22B63,
        CA_L_Pivot01 = 0x27D37413,
        CA_L_Run = 0xB9F565E7,
        CA_T_CarryPickup01 = 0x70AB580C,
        CA_T_CarryThrow01 = 0xA941FA98,
        CA_T_CarryThrow02 = 0xA941FA99,
        CA_T_CarryThrowBegin02 = 0xDE7D2BB0,
        CA_T_Close01 = 0x3B7DE61D,
        CA_T_OpenAttack01 = 0x67941E03,
        CA_T_Scan01 = 0x68FB3C96,
        Carried01 = 0x5CAAE14B,
        Carry_HammerSpin = 0x19A27D74,
        Carry_HammerSpinItem = 0x785C6D77,
        Carry_HammerStart = 0x1EAD52E0,
        Carry_HammerStartItem = 0x7D00BCA3,
        Carry_HammerThrow = 0x2EA3D800,
        Carry_Idle = 0xECCB539C,
        Carry_IdleItem = 0xEC90A01F,
        Carry_Pickup = 0xC13767C8,
        Carry_PickupFail = 0x00EA699A,
        Carry_PickupItem = 0x01564A0B,
        Carry_Throw = 0xEDAD6C66,
        Carry_ThrowItem = 0x02FC1409,
        Carry_Walk = 0xEEAAC901,
        Carry_WalkItem = 0xBF5B9314,
        CarryDeath01 = 0x598A528E,
        CarryDeath01X = 0xD1C83F02,
        CarryHit01 = 0x5914147D,
        CarryHit01X = 0x95467C4F,
        CarryHit02 = 0x5914147E,
        CarryHit02X = 0x95467CD2,
        CarryIdle01 = 0x37F94A68,
        CarryIdle01X = 0xA4911390,
        CarryPickup01 = 0x982B2E4C,
        CarryPickup01X = 0xDE18B13C,
        CarryThrow01 = 0xC1027758,
        CarryThrow01X = 0xC4431260,
        CarryThrow02 = 0xC1027759,
        CarryThrow02X = 0xC44312E3,
        CarryThrowBegin02 = 0x818175F0,
        CarryThrowLoop02 = 0x01D6EF51,
        CarryWalk01 = 0xC48DD9F5,
        CarryWalk01X = 0x949688B7,
        Cartwheel01 = 0xD27AB3AC,
        CD_L_CloseIdle01 = 0xDA301980,
        CD_L_OpenIdle01 = 0x2B3D98D4,
        CD_T_HitClose01 = 0x970858F3,
        CD_T_HitOpen01 = 0x41140545,
        CD_T_Taunt01 = 0x09D371F6,
        CG_L_Closed01 = 0x8B707303,
        CG_T_CloseDoor01 = 0xAF7B36F5,
        CH_L_Default = 0x7677BDB0,
        ChargeDone = 0x3628065A,
        ChargeLoop = 0x373A73C0,
        ChargePrep = 0x37C46E29,
        ChargeReset = 0xAAE57FEF,
        ChargeSkid = 0x382983BB,
        ChargeTeeter = 0x689CB5E5,
        Cheat01 = 0xCBF1F208,
        CHICKEN_L_IDLE01 = 0xD8AA8912,
        CHICKEN_L_IDLE02 = 0xD8AA8913,
        CHICKEN_L_RUN01 = 0x22E49743,
        CHICKEN_L_WALK01 = 0x653F189F,
        CHICKEN_T_FLYFORWARD01 = 0x710E1718,
        ChopLeftBegin = 0xA1CB1568,
        ChopLeftEnd = 0xD1E3343A,
        ChopLeftLoop = 0x683421E5,
        ChopRightBegin = 0x9F9E4C87,
        ChopRightEnd = 0x31509F21,
        ChopRightLoop = 0x3D31D61A,
        CL_L_CloseIdle01 = 0x70241D48,
        CL_L_FireWait01 = 0xECAFDF85,
        CL_L_OpenIdle01 = 0xCCA12B6C,
        CL_L_OpenLoop01 = 0x80AEAD74,
        CL_T_FireLobber01 = 0xA1BBBB74,
        CL_T_ManLobber01 = 0x0CD75226,
        CL_T_OpenDoor01 = 0x9AD183C6,
        CL_T_UnmanLobber01 = 0x17C2CF3D,
        Clap01 = 0x127C9F11,
        CLAW_SWING = 0xAE9B639E,
        CLBegin01 = 0x4A98F781,
        CLEnd01 = 0xBBBCE023,
        CLLoop01 = 0x05542ED6,
        Close01 = 0x6BF1C65D,
        Cloud_Attack01 = 0xD041D4A3,
        Cloud_Idle01 = 0xF9817753,
        CR_L_ClosedSpin01 = 0xEB6CBA46,
        CR_L_FireWait01 = 0x65BA8D77,
        CR_T_CloseDoor01 = 0x3DAABC28,
        CR_T_FireRocket01 = 0x1484E996,
        Crash = 0xA324C2E3,
        CrouchDodgeBack01 = 0xB5F2EAC5,
        CrouchDodgeFront01 = 0x74F67665,
        CrouchDodgeLeft01 = 0xCFBDFAA9,
        CrouchDodgeRight01 = 0x8873995C,
        CrouchDown01 = 0x880845F5,
        CrouchIdle01 = 0xAF0B38BF,
        CrouchRun01 = 0xD850CF52,
        CrouchUp01 = 0x1F5C62D6,
        cruise_bubble_aim = 0x4CF90A54,
        cruise_bubble_fire = 0x641BCFD7,
        cruise_bubble_fire2 = 0x3A3B5B37,
        cruise_bubble_idle = 0x64816669,
        CS_L_Idle01 = 0xD2BE535F,
        CS_L_Run01 = 0x86830832,
        CS_T_Start01 = 0xA7DE2CA5,
        Custom01 = 0x97FD8016,
        CV_L_Crouch = 0x5F538E75,
        Damage = 0x4E81D69F,
        Damage01 = 0xBDBC4158,
        Damage02 = 0xBDBC4159,
        Damage03 = 0xBDBC415A,
        Damage04 = 0xBDBC415B,
        DamageRadius = 0x3E1A8DBD,
        DanceBegin01 = 0xDB7797F3,
        DanceEnd01 = 0xDE84DF85,
        DanceLoop01 = 0xD1ABDDFC,
        DC_T_Close01 = 0xA7EFA6EA,
        DD_T_DamageDeath = 0x6684525B,
        DE_S_Death01 = 0x3AFF3697,
        Death = 0xB2F488D8,
        Death01 = 0x4A697059,
        Death02 = 0x4A69705A,
        Death03 = 0x4A69705B,
        DeathLandBack01 = 0xD1A55907,
        DeathLandFront01 = 0xA144E22B,
        Defeat = 0x93C999C7,
        Defeat01 = 0xF55595C0,
        Defeat02 = 0xF55595C1,
        Defeat03 = 0xF55595C2,
        Defeat04 = 0xF55595C3,
        Defeated01 = 0x0908F3E3,
        Defeated02 = 0x0908F3E4,
        Defeated03 = 0x0908F3E5,
        Defeated04 = 0x0908F3E6,
        Defeated05 = 0x0908F3E7,
        DefeatedGoo01 = 0x25C2336A,
        DefeatedProjectile01 = 0x5BCA87E4,
        DefeatGoo = 0x8AD1B6B8,
        Defend = 0x93C9A05E,
        Deflect_Done = 0xCFC143C6,
        Deflect_Loop = 0xD0D3B12C,
        Deflect_Prep = 0xD15DAB95,
        DERVISH_BEGIN = 0xA60C818F,
        DERVISH_END = 0x9C8345E9,
        DERVISH_LOOP = 0x181D2E72,
        DF_L_Wait01 = 0x03DCB90E,
        Dizzy01 = 0xF023B149,
        DizzyFall01 = 0x9A06E87C,
        DizzySit01 = 0x174E9783,
        DJumpLift01 = 0xF6D0B06A,
        DJumpStart01 = 0xB45C0945,
        Down = 0x093179C6,
        DR_L_Down = 0x2D845FCA,
        DR_L_DownCycle = 0x50C49A58,
        DR_L_Up = 0x1DB04EB3,
        Drive = 0xB4B49302,
        DriveSlippy = 0xED4AA653,
        ElbowDrop01 = 0xCBC4DC7B,
        Extra01 = 0xF72BBD49,
        FA_T_Fall01 = 0xB61E8BAF,
        Fail01 = 0x45040CA3,
        Failed = 0x45041775,
        Fall01 = 0x456AF574,
        Fall02 = 0x456AF575,
        Fall03 = 0x456AF576,
        Fall04 = 0x456AF577,
        Fall05 = 0x456AF578,
        Fall06 = 0x456AF579,
        FallHigh01 = 0x2982C55A,
        FallHigh03 = 0x2982C55C,
        FallHigh04 = 0x2982C55D,
        FallHigh05 = 0x2982C55E,
        Fast01 = 0x465D2CF9,
        FD_L_Fall01 = 0x76746F80,
        FD_L_Ground01 = 0xAF1AFABC,
        FD_S_Death = 0x82FDF3CB,
        FD_S_DeathOutOfTime = 0x9CDA34C7,
        FD_T_Hit01 = 0x7E75867C,
        FD_T_Land01 = 0x16FEB778,
        Fear01 = 0x8A2A0B45,
        Fidget01 = 0xE3879162,
        Fidget02 = 0xE3879163,
        Fidget03 = 0xE3879164,
        fire = 0x0974802E,
        FirstPerson01 = 0x1C72F062,
        FL_S_Death = 0x4B8820D3,
        Flee = 0x097542A2,
        Flee01 = 0x058FD673,
        fly = 0x00127BB3,
        FM_L_CloseIdle01 = 0xC955D782,
        FM_L_Follow01 = 0x1E49A48D,
        FM_T_DoorClose01 = 0x849B2030,
        FR_T_Begin01 = 0xC8E28B84,
        FR_T_Cycle01 = 0xDE18C095,
        FR_T_Cycle02 = 0xDE18C096,
        FR_T_Cycle03 = 0xDE18C097,
        Freeze01 = 0x19045B04,
        FudgeBlow01 = 0x0731ACBA,
        FudgeDone01 = 0x32BC6256,
        FudgeJump01 = 0x810900B6,
        FuriousArena = 0x73BDF5E8,
        FuriousTrench = 0xE506708F,
        GetUp01 = 0xB62A31CA,
        GolfToCrouch01 = 0xA74A92E8,
        GolfToIdle01 = 0xE0CCD8C2,
        Goo01 = 0xE8F84BD4,
        Goo02 = 0xE8F84BD5,
        GooDefeated = 0x95DB6CAD,
        Grab01 = 0x69DC6845,
        GrabExtendBegin01 = 0x294EECE0,
        GrabExtendLoop01 = 0x785F57CB,
        GrabIdle01 = 0x1B902645,
        GrabRetract01 = 0x122A7B16,
        GrabTossBackRecover01 = 0xAF030533,
        GrabTossForward01 = 0x77F93FB7,
        GrabTossForwardRecover01 = 0xCB720B03,
        GrappleExtend01 = 0xD2462ADE,
        GrappleExtend02 = 0xD2462ADF,
        GrappleGrab01 = 0x7E866D6C,
        GrappleHold01 = 0x46DB71A7,
        GrappleTran01 = 0x444166AF,
        GroundGrab01 = 0x75FFA284,
        GroundToss01 = 0x097C3CE7,
        GroundTossEnd01 = 0xA7CD0136,
        HA_L_Pivot01 = 0x41BE5F7A,
        HA_L_Shoot01 = 0xE971EB5B,
        HA_T_Notice01 = 0x2DE788DA,
        HangSwing01 = 0x919209C9,
        Hit = 0x00130037,
        HIT_BALLS = 0x48E53E6C,
        HIT_HEAD_BOTTOM = 0x9E2CFA26,
        HIT_HEAD_TOP = 0xA6AD1186,
        HIT_LEG = 0x5A44022E,
        Hit01 = 0xF9B97FB0,
        Hit02 = 0xF9B97FB1,
        Hit03 = 0xF9B97FB2,
        Hit04 = 0xF9B97FB3,
        Hit05 = 0xF9B97FB4,
        Hit2 = 0x09B91C57,
        HitBack01 = 0xB99F45CB,
        HitCrouchBack01 = 0xD4CAEC31,
        HitCrouchFront01 = 0x3D7F30A9,
        HitFront01 = 0x56290A77,
        HitLeft01 = 0xD36A55AF,
        HitRight01 = 0x69A62D6E,
        HM_L_Run = 0x8751744A,
        HM_L_Wait = 0x3F54C6F6,
        HOP_BEGIN = 0x430534FB,
        HOP_END = 0xF9251CF5,
        HOP_LOOP = 0x7EEE3996,
        HT_L_Light = 0x57D5C2C4,
        HT_L_LightLeft = 0x174F379B,
        HT_L_LightRight = 0x57652DDC,
        HT_T_Medium = 0x627777DB,
        HT_T_MediumCycle01 = 0x49825694,
        HT_T_MediumCycle02 = 0x49825695,
        HT_T_MediumLeft = 0xAFE2DDE2,
        HT_T_MediumRecover = 0x3A0EFA99,
        HT_T_MediumRight = 0x6AF34431,
        Hurt01 = 0x9C55B498,
        HurtBash01 = 0xC89503C8,
        HurtKnock01 = 0x7D64F326,
        HurtSmash01 = 0x33D99EA2,
        IA_L_FireCool01 = 0x4F73C596,
        IA_L_Idle01 = 0x56A27C5F,
        IA_L_Wait01 = 0xE2D27E6C,
        IA_T_Close01 = 0xF43166FF,
        IA_T_Fire01 = 0x77D5FB95,
        IA_T_First01 = 0x546968AB,
        IA_T_Open01 = 0xC8A10949,
        IA_T_Pivot01 = 0xA91121FD,
        ID_L_Cheer01 = 0xC0ADD6F7,
        ID_L_Comp01 = 0xAE48A04F,
        ID_L_Comp02 = 0xAE48A050,
        ID_L_Comp03 = 0xAE48A051,
        ID_L_Idle01 = 0xD2266088,
        ID_L_Scared01 = 0x7C3C55AC,
        ID_L_Stand0 = 0xBCB5C7F9,
        ID_L_Stand1 = 0xBCB5C7FA,
        ID_L_Wait01 = 0x5E566295,
        ID_L_Wait02 = 0x5E566296,
        ID_T_Extra01 = 0xB3E91EE6,
        Idle = 0x09DA16C0,
        Idle_Alert = 0x0C7818B9,
        IDLE_SYMMETRIC = 0xCDE2CA90,
        Idle01 = 0x6C9F2581,
        Idle01b = 0x95703145,
        Idle01c = 0x95703146,
        Idle02 = 0x6C9F2582,
        Idle03 = 0x6C9F2583,
        Idle04 = 0x6C9F2584,
        Idle05 = 0x6C9F2585,
        Idle06 = 0x6C9F2586,
        Idle07 = 0x6C9F2587,
        Idle08 = 0x6C9F2588,
        Idle09 = 0x6C9F2589,
        Idle10 = 0x6C9F2603,
        Idle11 = 0x6C9F2604,
        Idle12 = 0x6C9F2605,
        Idle13 = 0x6C9F2606,
        IdleHide = 0x7BA6C6FA,
        IdleLob = 0x9577959B,
        IN_L_Investigate01 = 0x8A41BDAF,
        IN_L_Investigate02 = 0x8A41BDB0,
        IN_L_Investigate03 = 0x8A41BDB1,
        IN_L_Poke01 = 0xBA1B466B,
        IN_T_Action = 0xE71A25CB,
        Inactive_sleep = 0x3753C823,
        Inactive01 = 0x3B75C3F4,
        Inactive02 = 0x3B75C3F5,
        Inactive03 = 0x3B75C3F6,
        Inactive04 = 0x3B75C3F7,
        Inactive05 = 0x3B75C3F8,
        Inactive06 = 0x3B75C3F9,
        Inactive07 = 0x3B75C3FA,
        Inactive08 = 0x3B75C3FB,
        Inactive09 = 0x3B75C3FC,
        Inactive10 = 0x3B75C476,
        IR_L_Idle = 0xAB8358E9,
        IR_L_Shoot = 0x7449A35E,
        JP_L_Fall = 0xD5616C8F,
        JP_L_JumpCycle01 = 0x06DA127D,
        JP_L_JumpFall01 = 0xB80CB53A,
        JP_S_JumpLand01 = 0xF4E51337,
        JP_T_JumpLand01 = 0x93ADA8B2,
        JP_T_JumpStart01 = 0x4B4898DD,
        JP_T_Land = 0xB2519AC7,
        JP_T_Start = 0xBD2A9296,
        Jump = 0x0A00D882,
        JUMP_BEGIN = 0xD624E4B0,
        JUMP_END = 0xB297F342,
        JUMP_LOOP = 0x64B1E2FD,
        JumpApex = 0xAE95B7F4,
        JumpApex01 = 0x52686C55,
        JumpD = 0x1E6ECACA,
        JumpDFall = 0x89EE2AC5,
        JumpDLand = 0x8ABBFD65,
        JumpFall = 0xAF3D51FD,
        JumpLand = 0xB00B249D,
        JumpLandSquash = 0xF6F73280,
        JumpLift01 = 0xA658EF86,
        JumpMelee01 = 0x4D7938DB,
        JumpStart01 = 0x87145499,
        JumpStart03 = 0x8714549B,
        JumpStart04 = 0x8714549C,
        KarateEnd = 0x328333A1,
        KarateLoop = 0xDA13D39A,
        KarateStart = 0x13AD1EE8,
        Land01 = 0x2AC73D14,
        Land02 = 0x2AC73D15,
        LandHigh01 = 0x69C12EFA,
        LandHigh02 = 0x69C12EFB,
        LandRun01 = 0x4A62A529,
        LanuchLandBack01 = 0x093E27F4,
        LassoAboutToDestroy = 0xCEB4C1B0,
        LassoDestroy = 0x6D7F7A88,
        LassoEnemyFight = 0x67A9F322,
        LassoEnemyLose = 0x3A45F693,
        LassoEnemyRope = 0x3B13C6AC,
        LassoEnemyWin = 0x9EBF0166,
        LassoFly = 0x9B0D9671,
        LassoGrab01 = 0x542CBF4F,
        LassoGuide_Grab01 = 0xB5538076,
        LassoGuide_Hold01 = 0x7DA884B1,
        LassoHold01 = 0x1C81C38A,
        LassoSwing = 0xE7816C60,
        LassoSwingCatch01 = 0x589AAF8C,
        LassoSwingCatch02 = 0x589AAF8D,
        LassoSwingRelease = 0x50F8247B,
        LassoThrow = 0xF70EF280,
        LassoWindup = 0x703497A5,
        LassoYank01 = 0xDAD13E34,
        Launch01 = 0x38B67214,
        LaunchBack01 = 0xA10F0F6F,
        LaunchEnd01 = 0xD203BC75,
        LaunchFront01 = 0xC45D3963,
        LaunchLandBack01 = 0xD1F5D6A2,
        LaunchLandFront01 = 0xCA75287C,
        LB_L_Pivot01 = 0x23B54B0F,
        LB_T_GunCock01 = 0xDCD87E15,
        LB_T_Lob01 = 0x8A5AB7D0,
        LCopter01 = 0xD90BE992,
        LCopterHeadUp01 = 0x223AF67D,
        LD_L_Launch01 = 0xF0D7D426,
        LD_T_FlameThrower01 = 0x39939673,
        LD_T_Laser01 = 0xD4FB275A,
        LD_T_Lob01 = 0xBC7D4312,
        LD_T_Start01 = 0x3676A911,
        Leap01 = 0x6F4349E5,
        Leap02 = 0x6F4349E6,
        Leap03 = 0x6F4349E7,
        Leap04 = 0x6F4349E8,
        LeapDone = 0x886A9B66,
        LeapLoop01 = 0x8EB2CBED,
        LeapLoop02 = 0x8EB2CBEE,
        LeapLoop03 = 0x8EB2CBEF,
        LeapLoop04 = 0x8EB2CBF0,
        LeapPrep = 0x8A070335,
        LedgeDown01 = 0x5F84E3E0,
        LedgeGrab01 = 0x83C5196E,
        LedgeIdle01 = 0x8687D6AA,
        LedgeJumpUpCycle01 = 0x1FD1EB19,
        LedgeJumpUpEnd01 = 0xA3A46932,
        LedgeJumpUpStart01 = 0x5F1C81F1,
        LedgeLeft01 = 0x89D88B39,
        LedgeRight01 = 0xC40B930C,
        LedgeThrowAbort01 = 0x3B8AD0E0,
        LedgeThrowReach01 = 0x362E63B3,
        LedgeThrowToss01 = 0xF3ABA215,
        LedgeThrowTossEnd01 = 0x240A1A10,
        LedgeUp01 = 0x275AB529,
        LEFTARM_L_IDLE01 = 0x334EDC56,
        LEFTARM_L_LL01 = 0x942BD5DE,
        LEFTARM_L_STIR01 = 0x1EF1B288,
        LEFTARM_L_UL01 = 0x95609051,
        Lick01 = 0xB5BD6F32,
        Light_Idle01 = 0xEBD76416,
        Lob = 0x00140F5B,
        Lose01 = 0x2132FC92,
        LP_L_Left = 0x0852D28D,
        LP_L_Right = 0xAC3D77B2,
        MC_L_AttackLoop01 = 0xE0298A11,
        MC_T_AttackStart01 = 0x303B7663,
        Melee01 = 0x63C46B45,
        Melee02 = 0x63C46B46,
        MeleeDone = 0xECB0E7C6,
        MeleeHover = 0x64BF8C30,
        MeleeLoop = 0xEDC3552C,
        MeleePrep = 0xEE4D4F95,
        Menu01 = 0x6C86D564,
        MH_L_Return01 = 0xCD2B66B8,
        MissileModel = 0xB21DA23B,
        MissileShrapnel = 0xA4B643D7,
        MissileSpeed = 0x1B9278BD,
        MissileSpringSpeed = 0x958BE5A0,
        MissileTrackTime = 0xAC86098A,
        MissleJetOffset = 0xE05CB937,
        MissleSmokeOffset = 0x47E0D0F1,
        MO_L_Run01 = 0x68A03F8C,
        MO_L_Walk01 = 0x144635FA,
        Move = 0x0A6633AD,
        move = 0x0A6633AD,
        Move_Alert = 0x198A1C9E,
        Move01 = 0x1D1E30D6,
        MV_L_Run0 = 0xEE989E96,
        MV_L_Run1 = 0xEE989E97,
        MV_L_Walk0 = 0x6D2F2E2A,
        MV_L_Walk1 = 0x6D2F2E2B,
        NoHeadGetUp01 = 0x813BFA31,
        NoHeadHit01 = 0x9980DB9F,
        NoHeadIdle01 = 0x2FA330CE,
        NoHeadReplace01 = 0xA226EF6C,
        NoHeadShock01 = 0x91F8D70E,
        NoHeadShot01 = 0x496FD2E8,
        NoHeadWaving01 = 0xE9680DC0,
        Notice = 0x185EF704,
        Notice01 = 0xB5FCD3E5,
        NT_S_Notice = 0x013F74D5,
        NU_L_Nuke = 0x8FBAEC4C,
        OC_L_Attack01 = 0x7C2944AB,
        OC_L_Ball01 = 0x5205E342,
        OC_T_Open01 = 0xD949CE05,
        OE_L_Wait01 = 0x9B2885EE,
        OI_L_Idle01 = 0x5E53096D,
        Open01 = 0x236FB213,
        Opened01 = 0x7D5DABCE,
        OT_L_HeadIdle01 = 0x83C5456A,
        OT_L_Idle01 = 0x788BF8AE,
        OT_L_JumpFly01 = 0x2DC008B1,
        OT_L_Walk01 = 0x0520883B,
        OT_T_BellySmash01 = 0xD564AC10,
        OT_T_HeadExtend01 = 0x05077448,
        OT_T_HeadHit01 = 0x9C06871B,
        OT_T_HeadRetract01 = 0xDD907B45,
        OT_T_JumpLand01 = 0x8217F45B,
        OT_T_JumpStart01 = 0x4BAD5058,
        OT_T_Throw01 = 0x949BD232,
        Outrage01 = 0xBAA9891C,
        Outrage02 = 0xBAA9891D,
        Outrage03 = 0xBAA9891E,
        Panic = 0x85134007,
        PatCarry01 = 0x8FA6BAE5,
        PatPickup01 = 0xFFF004F4,
        PatThrowBegin01 = 0xA9ECD117,
        PatThrowLoop01 = 0x8CE56F08,
        PD_T_Hit01 = 0xC4D7D45A,
        PickupWhif01 = 0x4ACDF773,
        PO_L_Point01 = 0xD8686F8A,
        PO_T_Begin01 = 0xC83AA157,
        PO_T_Prone01 = 0xFCCDD74A,
        PO_T_Recover01 = 0x94F3ED96,
        PO_T_Turn01 = 0x7145EE05,
        Pop_Down = 0x3909D12C,
        Pop_Up = 0x0EE42385,
        PopDown = 0x9B1E6F63,
        PopUp = 0x86F40AC4,
        PR_L_Flying01 = 0x3171DB8C,
        PR_L_Move01 = 0xE83256E6,
        PR_L_SpinAttack01 = 0x581169CB,
        PR_T_FromSleep01 = 0x1B1C9E4E,
        PR_T_Getup01 = 0x6A03D902,
        PR_T_Getup02 = 0x6A03D903,
        PR_T_Getup03 = 0x6A03D904,
        PR_T_LandBack01 = 0x89356157,
        PR_T_LandFront01 = 0x8FF9231B,
        PR_T_LandLeft01 = 0xA300713B,
        PR_T_LandRight01 = 0xA3764612,
        PR_T_OpenAttack01 = 0x2EF820EB,
        Pray = 0x0ACDDAEE,
        Pray01 = 0x4189151F,
        PT_L_Delay01 = 0xC1F19C6E,
        PT_L_Patrol01 = 0x09D960FF,
        PT_L_Stuck01 = 0xB3658373,
        PunchHitWallLeft01 = 0x257D99B7,
        PunchHitWallRight01 = 0x6981FD86,
        RA_L_AttackWait = 0xFF8CF0A4,
        RA_L_Swing = 0x3EB0A977,
        RA_T_Attack = 0xED1433A7,
        RA_T_AttackCharge = 0x53CA3D47,
        RA_T_AttackMulti = 0x1D68CDCA,
        RA_T_AttackOver = 0xF4C4AD53,
        RA_T_AttackSwing = 0x86FEE2B7,
        RA_T_AttackUp = 0x9F3AB1AE,
        RA_T_Over = 0x7C51EB2B,
        RA_T_Slam = 0x7CD8812C,
        RA_T_Spin = 0x7CD99169,
        RA_T_StopAttack = 0xC2EF3CF9,
        RA_T_VictoryDance = 0x9AF15D5C,
        RamHitWall01 = 0x0C76DFCC,
        RAT_L_IDLE01 = 0xB52BAAD6,
        RAT_L_IDLE02 = 0xB52BAAD7,
        RAT_L_RUN01 = 0xE7FEFB2F,
        RAT_T_STANDUP01 = 0xA3E05C3D,
        Recover = 0x4EA19430,
        Reload = 0x55D629FD,
        Respawn01 = 0xE5ED5B91,
        ReturnIdle01 = 0x22577009,
        Reversing = 0x5F349663,
        Ride01 = 0x9AF7EF49,
        RIGHTARM_R_IDLE01 = 0xA9672B41,
        RIGHTARM_R_LR01 = 0x7CA12367,
        RIGHTARM_R_UR01 = 0x7DD5DDDA,
        RN_L_Run = 0xE5FD9091,
        RS_L_Attack01 = 0x2AA0162E,
        RS_L_AttackMove01 = 0x29F1DE53,
        RS_L_Turn01 = 0xD31B9E8B,
        RS_T_Recover01 = 0xBFDECA00,
        RT_L_Aim01 = 0xDD22C0F2,
        RT_L_AttackReady01 = 0x7EB18658,
        RT_L_AttackWait01 = 0x5D1E92F6,
        RT_T_Attack01 = 0x681DB6C1,
        RT_T_GunCock01 = 0xE17406F9,
        RT_T_Reload01 = 0xD8BF8226,
        Run01 = 0xAADCAFE8,
        Run02 = 0xAADCAFE9,
        Run03 = 0xAADCAFEA,
        RunOutOfWorld01 = 0x9F20D855,
        SA_L_Idle01 = 0x5AF054F9,
        SA_L_ShuffleB = 0x81A255C5,
        SA_L_ShuffleL = 0x81A255CF,
        SA_L_ShuffleR = 0x81A255D5,
        SA_L_Taunt1 = 0xF62D9827,
        SA_L_Taunt2 = 0xF62D9828,
        SA_L_Walk01 = 0xE784E486,
        SA_T_SlamDown01 = 0x42ADD57C,
        SA_T_SlampUp01 = 0xDDB8266F,
        SC_L_Move01 = 0xB31CA314,
        SC_L_Turn = 0xA8B79CEB,
        SC_T_Action01 = 0xAB9E0D05,
        Scare_Done = 0xC797ADB9,
        Scare_Loop = 0xC8AA1B1F,
        SD_L_Idle = 0x1E9F9099,
        SD_L_Shield01 = 0x8306850B,
        SD_T_Sink = 0xFC1A4478,
        SH_L_Aim01 = 0x842A1EC9,
        SH_L_Alert01 = 0x16407174,
        SH_T_Shoot01 = 0x546A9C4B,
        Shield_Idle01 = 0xAC45B65B,
        Shiver01 = 0x2FE25804,
        Shocked01 = 0x79CAA902,
        Shoot = 0xBAACC863,
        Shoot_Done = 0x6B2722AA,
        Shoot_Loop = 0x6C399010,
        Shoot_Prep = 0x6CC38A79,
        Shoot01 = 0xC8850D3C,
        Shoot02 = 0xC8850D3D,
        Sit01 = 0xBAD0552B,
        SitShock01 = 0xC8CD4045,
        SJ_L_JumpCycle01 = 0x29BCBCEA,
        SK_S_Death = 0xF45D0D39,
        Slip01 = 0xCBD3C319,
        SlipIdle01 = 0x102A9B59,
        SlipRun01 = 0x5DF14B30,
        Slow01 = 0xCCA369FA,
        SM_L_Idle = 0x513350FC,
        SM_T_Shooting = 0x4C7F80C7,
        SmackLeft01 = 0x0BC283F7,
        SmackRight01 = 0x3EC5DC46,
        SMASH_ROCK = 0x6B641D14,
        SmashEnd = 0xA6F7757F,
        SmashHitLeft = 0x3F667622,
        SmashHitRight = 0xDB4A2CF1,
        SmashLoop = 0x71918834,
        SmashStart = 0x990089B6,
        SP_L_BlockLoop01 = 0x45E690A1,
        SP_L_DownIdle = 0x452A37D3,
        SP_L_Follow01 = 0x42FDCA3B,
        SP_L_Run01 = 0x78B94D7F,
        SP_L_Sleep01 = 0xFFB516FB,
        SP_L_UpIdle = 0x60F4C184,
        SP_T_BlockEnd02 = 0x087BD315,
        SP_T_BlockStart01 = 0x4B6560E3,
        SP_T_GoingDown = 0xE193EF43,
        SP_T_GoingUp = 0x89D623A4,
        SP_T_Open01 = 0x368256B0,
        SpatulaGrab01 = 0x42919C0F,
        Spawn01 = 0xAFF84B08,
        SpawnKids01 = 0x43BEEC19,
        Special01 = 0x025C081A,
        Spin_Loop = 0x277D8F25,
        Spin_Prep = 0x2807898E,
        Spin_Throw = 0xC0BE9C29,
        SpinBegin01 = 0x59CB0E18,
        SpinLeft = 0x49F64771,
        Spinning01 = 0x4CA9A447,
        SpinRight = 0x42E2485E,
        SpinStop01 = 0xF77A9BED,
        Spit01 = 0x120BA881,
        Spit02 = 0x120BA882,
        Spook_Loop = 0x5D1D160D,
        SpringboardCompress01 = 0x2B105984,
        SpringboardCompressed01 = 0xCDD621C7,
        SpringboardIdle01 = 0xE4D76026,
        SpringboardLaunch01 = 0x2A09B0E1,
        SR_L_Search01 = 0x1AC31670,
        ST_L_Left01 = 0x172F03E1,
        ST_L_Right01 = 0x174B5104,
        ST_L_Turn01 = 0x0DC6D597,
        ST_L_Wait01 = 0xA00E515F,
        STAB = 0x0B3549BA,
        StompL01 = 0xF0D7C57C,
        StompR01 = 0xF0D957B2,
        Stun = 0x0B355402,
        stun_begin = 0x81681430,
        Stun_Carry = 0x926F7A1E,
        stun_end = 0xE98006C2,
        Stun_Loop = 0x7D73DD7D,
        stun_loop = 0x7D73DD7D,
        Stun_Pickup = 0x3F2CA1A9,
        Stun_Prep = 0x7DFDD7E6,
        StunBegin01 = 0xD5F4D730,
        StunDone = 0xE5E475C4,
        StunFall = 0xE625657D,
        StunJump = 0xE6B3D924,
        StunLand = 0xE6F3381D,
        StunLoop = 0xE6F6E32A,
        StunLoop01 = 0xBC22133B,
        StunPrep = 0xE780DD93,
        Success = 0xB9F8D787,
        SW_T_LeverDown = 0x8FF25506,
        SW_T_LeverUp = 0xF0F8BD0F,
        SWARM_L_IDLE01 = 0xB56921FF,
        SWARM_L_MOVE01 = 0x65E82D54,
        Swim01 = 0x8CE9CF79,
        SwimDeath01 = 0xAECE6D01,
        SwimEnter01 = 0x86AC4A2D,
        SwimExit01 = 0x766EDAF7,
        SwimFallEnter01 = 0xCD584416,
        SwimHit01 = 0xDBA07918,
        SwimIdle01 = 0x05D0C5B9,
        SwimMove01 = 0xB64FD10E,
        SwimPullUp01 = 0x9B9862AD,
        SwimReach01 = 0x8E4BCB94,
        SwipeLeftBegin = 0x24723908,
        SwipeLeftEnd = 0x211002DA,
        SwipeLeftLoop = 0xEC21DDC5,
        SwipeRightBegin = 0x7B258767,
        SwipeRightEnd = 0xB53E5B01,
        SwipeRightLoop = 0xBFD8F9BA,
        TA_L_Idle = 0xD17F9619,
        TA_L_Overheat = 0xE116F201,
        TA_T_Shooting = 0x1BBCFCF4,
        TA_T_Taunt01 = 0x60A79E26,
        TA_T_Throw01 = 0x0CBFA20E,
        TailLeft = 0x07C97923,
        TailRight = 0x65F4B674,
        TailSlide01 = 0x6B28A5B6,
        TailSlideDJumpApex01 = 0x5802C4F8,
        TailSlideFall01 = 0xE966BCF9,
        TailSlideJumpApex01 = 0xEE2C1B6A,
        TailSlideJumpStart01 = 0x3C36EC58,
        TailSlideLand01 = 0xCEC30499,
        Talk01 = 0x06A6D2B5,
        Talk02 = 0x06A6D2B6,
        Talk03 = 0x06A6D2B7,
        Talk04 = 0x06A6D2B8,
        TarTar_Slosh01 = 0x79405319,
        Taunt = 0xCB4BF12A,
        Taunt01 = 0x05C9913B,
        Taunt02 = 0x05C9913C,
        Taunt03 = 0x05C9913D,
        Taunt04 = 0x05C9913E,
        Taunt1 = 0x07DC68AF,
        Taunt2 = 0x07DC68B0,
        TB_L_FlameThrower01 = 0xDBA6ACDD,
        TB_L_Lasers01 = 0x256C0671,
        TB_L_Lob01 = 0x837AE420,
        TD_L_Death01 = 0x113B1137,
        TD_T_Hit01 = 0x143259E6,
        TD_T_Hit01_B = 0xE34C8BF5,
        TD_T_Hit01_F = 0xE34C8BF9,
        TD_T_Hit01_L = 0xE34C8BFF,
        TD_T_Hit01_R = 0xE34C8C05,
        TD_T_HitMelee01 = 0x0D8185E4,
        TeleportBegin01 = 0x92D7446B,
        TeleportEnd01 = 0x7E21EE3D,
        TeleportLoop01 = 0x7F0A6624,
        Test01 = 0x4DD02687,
        TF_L_FlameThrower01 = 0xB3DF65E9,
        TF_T_FlipFlameFwdLaserBk01 = 0x83E851AC,
        TF_T_FlipFlameFwdLobBk01 = 0x491712DC,
        TF_T_Reload01 = 0xAB10514E,
        TG_L_Pivot01 = 0x1C20E334,
        TG_L_Wait01 = 0x44FCB501,
        TG_T_FlipLobFwdFlameBk01 = 0x38F5BAD5,
        TG_T_FlipLobFwdLaserBk01 = 0x6A9CF7E9,
        TG_T_Lob01 = 0xA6661F0D,
        TG_T_Reload01 = 0x49D8E6C9,
        TH_T_Thaw = 0xF2E48E3C,
        THIEF_L_ATTACK01 = 0x8CF12681,
        THIEF_L_IDLE01 = 0xF28CDBC1,
        THIEF_L_MOVE01 = 0xA30BE716,
        THIEF_L_MOVEALERT01 = 0xC179A69C,
        THIEF_L_NOTICE01 = 0xA20AFC25,
        THIEF_L_STUN01 = 0xDFCA4913,
        THROW_ROCK = 0x999C1F66,
        TL_L_Laser01 = 0x395A5372,
        TL_T_FromFlame01 = 0x165B5B50,
        TL_T_FromLob01 = 0xDA3429AC,
        TL_T_Reload01 = 0x63C3D230,
        ToguePrep = 0x7887635D,
        TongueDJumpApex01 = 0x1E143F21,
        TongueDone = 0x049BD3DA,
        TongueFall01 = 0xF2F271EC,
        TongueJump01 = 0x403937CB,
        TongueJumpXtra01 = 0xF3ADA9F6,
        TongueLand01 = 0xD84EB98C,
        TongueLoop = 0x05AE4140,
        TonguePrep = 0x06383BA9,
        TongueSlide01 = 0x181B635A,
        TongueStart01 = 0x69B4386B,
        TongueTumble01 = 0xF39C718C,
        Toss_Loop = 0xC1B8A474,
        Toss_Prep = 0xC2429EDD,
        TP_L_Cycle = 0x45C8A394,
        TP_T_NoRecover = 0xE31E6505,
        TP_T_Recover = 0xAFF46602,
        TP_T_Start = 0x038CE074,
        Triggered01 = 0x6C8CB22C,
        Triggered02 = 0x6C8CB22D,
        Triggered03 = 0x6C8CB22E,
        Triggered04 = 0x6C8CB22F,
        Turret01 = 0x65CA55ED,
        UD_L_DownIdle01 = 0x2E7FED3A,
        UD_L_UpIdle01 = 0x87226C83,
        UD_T_GoingDown01 = 0x73DB8146,
        UD_T_GoingUp01 = 0x047E42DF,
        UM_COMMAND_TROOPS = 0x82673D48,
        UM_FREEZE_STOP = 0xD9DF8E43,
        UM_IDLE = 0x33892F73,
        UM_IDLE_ALERT = 0x6E4E6974,
        UM_IDLE_NUKE = 0x1DF3B795,
        UM_JUMP = 0x33AFF135,
        UM_MISSILE_IDLE = 0x74F06D6C,
        UM_MISSILE_READY = 0x7522D32B,
        UM_MISSILE_SHOOT_L = 0xD9F55B88,
        UM_MISSILE_SHOOT_R = 0xD9F55B8E,
        UM_MISSILE_STOP = 0x764BA79E,
        UM_MONO_HIT_HARD = 0x0EEE4154,
        UM_MONO_HIT_LIGHT = 0xEB31D515,
        UM_RAM_LOOP = 0x7E236470,
        UM_RAM_READY = 0xF413F2DF,
        UM_RAM_STOP = 0x7F14D2DA,
        UM_SLASH_HIT = 0x3FE63BC6,
        UM_SLASH_LOOP = 0xB35B5CB5,
        UM_SLASH_READY = 0x2FB7FE2E,
        UM_SLASH_STOP = 0xB44CCB1F,
        UM_SWING_DIZZY = 0x139B9388,
        UM_SWING_HIT = 0x0BB72B77,
        UM_SWING_LOOP = 0xFF460448,
        UM_SWING_READY = 0x08CBBE67,
        UM_SWING_STOP = 0x003772B2,
        UM_TAUNT_LOOP_01 = 0xE3966B28,
        UM_TAUNT_LOOP_02 = 0xE3966B29,
        UM_TAUNT_LOOP_03 = 0xE3966B2A,
        Up = 0x00002BCF,
        UpKnockback = 0xD4E37430,
        Victory = 0x1026E6D6,
        Victory01 = 0xBFC83847,
        Victory02 = 0xBFC83848,
        Victory03 = 0xBFC83849,
        Victory04 = 0xBFC8384A,
        VS_L_FirePause01 = 0xC109777C,
        VS_L_Turn01 = 0x6E6DF52F,
        VS_L_WaitWatch01 = 0xF0FDA6A2,
        VS_T_Fire01 = 0x95B8EE20,
        VS_T_Notice01 = 0xE100EEAE,
        VS_T_WhosThere01 = 0x9D3C326F,
        WA_L_Run = 0x0DE866C3,
        WAITER_L_HITREACT01 = 0x8D9C3209,
        WAITER_L_IDLE01 = 0x93508395,
        WAITER_L_RUN01 = 0x5EF19544,
        Walk01 = 0xF933B50E,
        Walk02 = 0xF933B50F,
        Walk03 = 0xF933B510,
        WalkLeft = 0x4EF9E54C,
        WalkRight = 0xD3BC0F6F,
        WallFall01 = 0xB7F9C3AA,
        WallFlight01 = 0x529928E3,
        WallFlight02 = 0x529928E4,
        WallLand01 = 0x9D560B4A,
        WallLaunch01 = 0x9FB3D3FA,
        WD_S_Down01 = 0x8E8BDD49,
        WD_S_Up01 = 0x6521708A,
        Weep01 = 0x3E7BBE42,
        WH_T_Smack = 0xB59670A2,
        WH_T_SmackSink = 0x3F193E49,
        WI_L_Rest01 = 0x7F2020D5,
        WI_T_End01 = 0xD90ACAB8,
        Wiggle01 = 0xC4C2662C,
        WL_T_Fire01 = 0x31AF1A14,
        WL_T_Start01 = 0x3FB9C2A2,
        Yawn01 = 0xF1B66AB8,
        Yawn02 = 0xF1B66AB9,
        Yawn03 = 0xF1B66ABA,
        Yawn04 = 0xF1B66ABB,
        ZipCycle01 = 0x4D428B52,
        ZipDeath01 = 0x39970B80,
        ZipDown01 = 0x99832444,
        ZipGrab01 = 0xBDC359D2,
        ZipHit01 = 0x13C5085F,
        ZipSwitchLeftCycle01 = 0xA8EE0EBF,
        ZipSwitchLeftHand01 = 0xC41F4A24,
        ZipSwitchLeftLaunch01 = 0x85D117D0,
        ZipSwitchRightCycle01 = 0xD39FCEE0,
        ZipSwitchRightLand01 = 0xF8DDCB7B,
        ZipSwitchRightLaunch01 = 0x5EC668B3,
    }
}