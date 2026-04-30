namespace EdiFabric.Rules.X12005010X231999 {
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class M_999 {
    [XmlElement(Order=0)]
    public S_ST S_ST {get; set;}
    [XmlElement(Order=1)]
    public S_AK1 S_AK1 {get; set;}
    [XmlElement("G_TS999_2000",Order=2)]
    public List<G_TS999_2000> G_TS999_2000 {get; set;}
    [XmlElement(Order=3)]
    public S_AK9 S_AK9 {get; set;}
    [XmlElement(Order=4)]
    public S_SE S_SE {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_ST {
    [XmlElement(Order=0)]
    public X12_ID_143 D_ST01 {get; set;}
    [XmlElement(Order=1)]
    public string D_ST02 {get; set;}
    [XmlElement(Order=2)]
    public string D_ST03 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_143 {
        [XmlEnum("999")]
        Item999,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AK1 {
    [XmlElement(Order=0)]
    public string D_AK101 {get; set;}
    [XmlElement(Order=1)]
    public string D_AK102 {get; set;}
    [XmlElement(Order=2)]
    public string D_AK103 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS999_2000 {
    [XmlElement(Order=0)]
    public S_AK2 S_AK2 {get; set;}
    [XmlElement("G_TS999_2100",Order=1)]
    public List<G_TS999_2100> G_TS999_2100 {get; set;}
    [XmlElement(Order=2)]
    public S_IK5 S_IK5 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AK2 {
    [XmlElement(Order=0)]
    public string D_AK201 {get; set;}
    [XmlElement(Order=1)]
    public string D_AK202 {get; set;}
    [XmlElement(Order=2)]
    public string D_AK203 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS999_2100 {
    [XmlElement(Order=0)]
    public S_IK3 S_IK3 {get; set;}
    [XmlElement("S_CTX_Seg",Order=1)]
    public List<S_CTX_Seg> S_CTX_Seg {get; set;}
    [XmlElement(Order=2)]
    public S_CTX_BU S_CTX_BU {get; set;}
    [XmlElement("G_TS999_2110",Order=3)]
    public List<G_TS999_2110> G_TS999_2110 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_IK3 {
    [XmlElement(Order=0)]
    public string D_IK301 {get; set;}
    [XmlElement(Order=1)]
    public string D_IK302 {get; set;}
    [XmlElement(Order=2)]
    public string D_IK303 {get; set;}
    [XmlElement(Order=3)]
    public string D_IK304 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CTX_Seg {
    [XmlElement("C_CTX_Seg1",Order=0)]
    public List<C_CTX_Seg1> C_CTX_Seg1 {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_721 D_CTX_Seg2 {get; set;}
    [XmlElement(Order=2)]
    public string D_CTX_Seg3 {get; set;}
    [XmlElement(Order=3)]
    public string D_CTX_Seg4 {get; set;}
    [XmlElement(Order=4)]
    public C_CTX_Seg5 C_CTX_Seg5 {get; set;}
    [XmlElement(Order=5)]
    public C_CTX_Seg6 C_CTX_Seg6 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CTX_Seg1 {
    [XmlElement("D_CTX_Seg1.1",Order=0)]
    public X12_ID_9999 D_CTX_Seg11 {get; set;}
    [XmlElement("D_CTX_Seg1.2",Order=1)]
    public string D_CTX_Seg12 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_9999 {
        [XmlEnum("SITUATIONAL TRIGGER")]
        SITUATIONALTRIGGER,
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_721 {
        AAA,
        ACD,
        ACK,
        ACS,
        ACT,
        AD1,
        ADI,
        ADJ,
        ADT,
        ADV,
        ADX,
        AEI,
        AES,
        AIN,
        AK1,
        AK2,
        AK3,
        AK4,
        AK5,
        AK9,
        AM1,
        AMT,
        ANI,
        AOC,
        AOI,
        AOL,
        AOR,
        AP1,
        APE,
        API,
        APR,
        ARC,
        ARS,
        ASI,
        ASL,
        ASM,
        ASO,
        AST,
        AT1,
        AT2,
        AT3,
        AT4,
        AT5,
        AT6,
        AT7,
        AT8,
        AT9,
        ATA,
        ATH,
        ATN,
        ATR,
        ATV,
        AVA,
        AWD,
        AXL,
        B1,
        B2,
        B3,
        B4,
        B9,
        B10,
        B11,
        B12,
        B13,
        B2A,
        B3A,
        B3B,
        B9A,
        BA1,
        BA2,
        BAA,
        BAK,
        BAL,
        BAT,
        BAU,
        BAX,
        BBC,
        BC,
        BCA,
        BCD,
        BCH,
        BCI,
        BCM,
        BCO,
        BCP,
        BCQ,
        BCS,
        BCT,
        BCU,
        BDD,
        BDS,
        BEG,
        BEN,
        BEP,
        BFR,
        BFS,
        BGF,
        BGN,
        BGP,
        BHT,
        BIA,
        BIG,
        BIN,
        BIX,
        BJF,
        BL,
        BLI,
        BLN,
        BLR,
        BLS,
        BMA,
        BMG,
        BMM,
        BMP,
        BMS,
        BNR,
        BNX,
        BOL,
        BOR,
        BOS,
        BOX,
        BPA,
        BPP,
        BPR,
        BPT,
        BQR,
        BQT,
        BR,
        BRA,
        BRC,
        BRR,
        BSC,
        BSD,
        BSF,
        BSI,
        BSN,
        BSR,
        BSS,
        BSW,
        BT1,
        BTA,
        BTC,
        BTI,
        BTP,
        BTR,
        BTS,
        BUY,
        BVA,
        BVB,
        BVP,
        BVS,
        BW,
        BX,
        C2,
        C3,
        C4,
        C8,
        C8C,
        CA1,
        CAD,
        CAI,
        CAL,
        CAS,
        CAT,
        CB1,
        CBS,
        CCI,
        CD,
        CD1,
        CD2,
        CD3,
        CDA,
        CDD,
        CDI,
        CDS,
        CED,
        CF1,
        CF2,
        CFI,
        CFT,
        CGS,
        CHB,
        CHR,
        CI,
        CIC,
        CID,
        CII,
        CIV,
        CL1,
        CLD,
        CLI,
        CLM,
        CLP,
        CLR,
        CM,
        CMA,
        CMC,
        CN1,
        COB,
        COM,
        CON,
        CPR,
        CQ,
        CR1,
        CR2,
        CR3,
        CR4,
        CR5,
        CR6,
        CR7,
        CR8,
        CRC,
        CRD,
        CRI,
        CRO,
        CRS,
        CRT,
        CRV,
        CS,
        CSB,
        CSC,
        CSD,
        CSE,
        CSF,
        CSH,
        CSI,
        CSM,
        CSS,
        CST,
        CSU,
        CT,
        CTB,
        CTC,
        CTP,
        CTT,
        CTX,
        CUR,
        CV,
        CYC,
        D9,
        DAD,
        DAI,
        DAM,
        DB,
        DD,
        DDI,
        DED,
        DEF,
        DEG,
        DEL,
        DEP,
        DEX,
        DFI,
        DH,
        DIS,
        DK,
        DL,
        DLV,
        DM,
        DMA,
        DMG,
        DMI,
        DN,
        DN1,
        DN2,
        DOS,
        DP,
        DPN,
        DR,
        DRT,
        DSB,
        DTM,
        DTP,
        DVI,
        E1,
        E4,
        E5,
        E6,
        E8,
        E01,
        E03,
        E10,
        E13,
        E20,
        E22,
        E24,
        E26,
        E30,
        E34,
        E40,
        E41,
        EA,
        EB,
        EC,
        ED,
        EDF,
        EFI,
        EI,
        EIA,
        ELV,
        EM,
        EMP,
        EMS,
        EMT,
        ENE,
        ENM,
        ENR,
        ENT,
        EQ,
        EQD,
        ER,
        ERI,
        ERP,
        ES,
        ESI,
        ETD,
        EXI,
        F9,
        F01,
        F02,
        F04,
        F05,
        F07,
        F09,
        F10,
        F11,
        F12,
        F13,
        F14,
        F6X,
        FA1,
        FA2,
        FAA,
        FAC,
        FBB,
        FC,
        FCL,
        FDA,
        FG,
        FGS,
        FH,
        FIR,
        FIS,
        FK,
        FNA,
        FOB,
        FOS,
        FPT,
        FRM,
        FSA,
        FST,
        FTH,
        G1,
        G2,
        G3,
        G4,
        G5,
        G01,
        G05,
        G07,
        G08,
        G11,
        G12,
        G13,
        G14,
        G15,
        G17,
        G18,
        G19,
        G20,
        G21,
        G22,
        G23,
        G24,
        G25,
        G26,
        G28,
        G29,
        G30,
        G31,
        G32,
        G33,
        G35,
        G36,
        G37,
        G38,
        G39,
        G40,
        G42,
        G43,
        G45,
        G46,
        G47,
        G48,
        G49,
        G50,
        G51,
        G53,
        G54,
        G55,
        G61,
        G62,
        G63,
        G66,
        G68,
        G69,
        G70,
        G72,
        G73,
        G76,
        G82,
        G83,
        G84,
        G85,
        G86,
        G87,
        G88,
        G89,
        G91,
        G92,
        G93,
        G94,
        G95,
        GA,
        GDP,
        GE,
        GF,
        GH,
        GID,
        GR,
        GR2,
        GR4,
        GR5,
        GRI,
        GRP,
        GS,
        GY,
        H1,
        H2,
        H3,
        H5,
        H6,
        HAD,
        HC,
        HCP,
        HCR,
        HD,
        HI,
        HL,
        HLH,
        HPL,
        HS,
        HSD,
        IA,
        IC,
        ICH,
        ICM,
        ID,
        ID1,
        ID2,
        ID3,
        ID4,
        IDB,
        IDC,
        IEA,
        IGI,
        IH,
        III,
        IIS,
        IK3,
        IK4,
        IK5,
        IM,
        IMA,
        IMC,
        IMM,
        IMP,
        IN1,
        IN2,
        INC,
        IND,
        INI,
        INQ,
        INR,
        INS,
        INT,
        INV,
        INX,
        IRA,
        IRP,
        IS1,
        IS2,
        ISA,
        ISB,
        ISC,
        ISD,
        ISE,
        ISI,
        ISR,
        ISS,
        IT,
        IT1,
        IT3,
        IT8,
        ITA,
        ITC,
        ITD,
        IV1,
        JCT,
        JID,
        JIL,
        JIT,
        JL,
        JS,
        K1,
        K2,
        K3,
        L0,
        L1,
        L3,
        L4,
        L5,
        L7,
        L8,
        L9,
        L10,
        L11,
        L12,
        L13,
        L1A,
        LAD,
        LC,
        LC1,
        LCD,
        LCT,
        LDT,
        LE,
        LEP,
        LEQ,
        LET,
        LFG,
        LFH,
        LFI,
        LH,
        LH1,
        LH2,
        LH3,
        LH4,
        LH6,
        LHE,
        LHR,
        LHT,
        LIC,
        LID,
        LIE,
        LIN,
        LM,
        LN,
        LN1,
        LN2,
        LOC,
        LOD,
        LP,
        LQ,
        LRQ,
        LS,
        LS1,
        LT,
        LTE,
        LTR,
        LUC,
        LUI,
        LV,
        LX,
        M0,
        M1,
        M2,
        M3,
        M7,
        M10,
        M11,
        M12,
        M13,
        M14,
        M15,
        M20,
        M21,
        M7A,
        MAN,
        MBL,
        MC,
        MCD,
        MCT,
        MEA,
        MI,
        MI1,
        MIA,
        MIC,
        MII,
        MIN,
        MIR,
        MIS,
        MIT,
        MKS,
        MLA,
        MLS,
        MNC,
        MOA,
        MPI,
        MPP,
        MRC,
        MS,
        MS1,
        MS2,
        MS3,
        MS4,
        MS5,
        MS6,
        MSG,
        MSI,
        MSS,
        MTX,
        N1,
        N2,
        N3,
        N4,
        N5,
        N7,
        N8,
        N9,
        N10,
        N11,
        N12,
        N7A,
        N7B,
        N8A,
        NA,
        NCA,
        NCD,
        NM1,
        NTE,
        NX1,
        NX2,
        OBI,
        OD,
        OI,
        OID,
        OOI,
        OP,
        OPS,
        OPX,
        OQS,
        ORI,
        OTI,
        P1,
        P2,
        P4,
        P5,
        PAD,
        PAI,
        PAL,
        PAM,
        PAS,
        PAT,
        PAY,
        PBI,
        PCL,
        PCR,
        PCS,
        PCT,
        PD,
        PDD,
        PDE,
        PDI,
        PDL,
        PDP,
        PDR,
        PDS,
        PEN,
        PER,
        PEX,
        PI,
        PID,
        PIN,
        PKD,
        PKG,
        PKL,
        PL,
        PLA,
        PLB,
        PLC,
        PLD,
        PLI,
        PM,
        PO1,
        PO3,
        PO4,
        POC,
        POD,
        PPA,
        PPD,
        PPL,
        PPY,
        PR,
        PR1,
        PR2,
        PRC,
        PRD,
        PRF,
        PRI,
        PRJ,
        PRM,
        PRR,
        PRS,
        PRT,
        PRV,
        PS,
        PS1,
        PSA,
        PSC,
        PSD,
        PT,
        PTD,
        PTF,
        PTS,
        PUN,
        PWK,
        PYD,
        PYM,
        PYT,
        Q2,
        Q3,
        Q5,
        Q6,
        Q7,
        Q8,
        QTY,
        R1,
        R2,
        R3,
        R4,
        R9,
        R11,
        R12,
        R13,
        R2A,
        R2B,
        R2C,
        R2D,
        RA,
        RAB,
        RAP,
        RAT,
        RB,
        RC,
        RCD,
        RCR,
        RD,
        RDD,
        RDI,
        RDM,
        RDR,
        RDT,
        RE,
        REA,
        REC,
        RED,
        REF,
        REL,
        REN,
        REP,
        REQ,
        RES,
        RET,
        RH,
        RIC,
        RLD,
        RLT,
        RMR,
        RMT,
        RO,
        RP,
        RPA,
        RQS,
        RRA,
        RS,
        RSC,
        RSD,
        RST,
        RT,
        RT1,
        RTE,
        RTS,
        RTT,
        RU1,
        RU2,
        RU3,
        RYL,
        S1,
        S2,
        S5,
        S9,
        S3A,
        S3E,
        S3S,
        S4A,
        S4E,
        S4S,
        SA,
        SAC,
        SAD,
        SAL,
        SB,
        SBR,
        SBT,
        SC,
        SCA,
        SCD,
        SCH,
        SCL,
        SCM,
        SCN,
        SCP,
        SCR,
        SCS,
        SCT,
        SD1,
        SDP,
        SDQ,
        SE,
        SER,
        SES,
        SFC,
        SG,
        SHD,
        SHI,
        SHP,
        SHR,
        SI,
        SID,
        SII,
        SIN,
        SL1,
        SLA,
        SLI,
        SLN,
        SMA,
        SMB,
        SMD,
        SMO,
        SMR,
        SMS,
        SN1,
        SOI,
        SOM,
        SP,
        SPA,
        SPE,
        SPI,
        SPK,
        SPR,
        SPS,
        SPY,
        SR,
        SRA,
        SRD,
        SRE,
        SRM,
        SRT,
        SS,
        SSC,
        SSD,
        SSE,
        SSS,
        SST,
        ST,
        STA,
        STC,
        STP,
        STS,
        SUM,
        SUP,
        SV,
        SV1,
        SV2,
        SV3,
        SV4,
        SV5,
        SV6,
        SV7,
        SVA,
        SVC,
        SVD,
        SW,
        SWC,
        SWD,
        SWR,
        T1,
        T2,
        T3,
        T6,
        T8,
        TA,
        TA1,
        TA3,
        TAX,
        TBA,
        TBI,
        TC2,
        TCD,
        TD1,
        TD3,
        TD4,
        TD5,
        TDS,
        TDT,
        TED,
        TEM,
        TER,
        TF,
        TFA,
        TFD,
        TFM,
        TFR,
        TFS,
        THE,
        TI,
        TIA,
        TID,
        TII,
        TIS,
        TLN,
        TMD,
        TOA,
        TOO,
        TOV,
        TPB,
        TPD,
        TRF,
        TRL,
        TRN,
        TRS,
        TS,
        TS2,
        TS3,
        TSD,
        TSI,
        TSP,
        TST,
        TSU,
        TT,
        TUD,
        TXI,
        TXN,
        TXP,
        UC,
        UCS,
        UD,
        UDA,
        UIT,
        UM,
        UQS,
        UR,
        USD,
        USI,
        UWI,
        V1,
        V2,
        V3,
        V4,
        V5,
        V9,
        VAD,
        VAR,
        VAT,
        VC,
        VC1,
        VDI,
        VEH,
        VID,
        VR,
        VRC,
        W1,
        W2,
        W3,
        W4,
        W5,
        W6,
        W01,
        W03,
        W04,
        W05,
        W06,
        W07,
        W08,
        W09,
        W10,
        W12,
        W13,
        W14,
        W15,
        W17,
        W18,
        W19,
        W20,
        W27,
        W28,
        W66,
        W76,
        WGP,
        WLD,
        WS,
        X1,
        X2,
        X4,
        X7,
        X01,
        X02,
        XD,
        XH,
        XPO,
        XQ,
        Y1,
        Y2,
        Y3,
        Y4,
        Y5,
        Y6,
        Y7,
        YNQ,
        ZA,
        ZC1,
        ZD,
        ZR,
        ZT,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CTX_Seg5 {
    [XmlElement("D_CTX_Seg5.1",Order=0)]
    public string D_CTX_Seg51 {get; set;}
    [XmlElement("D_CTX_Seg5.2",Order=1)]
    public string D_CTX_Seg52 {get; set;}
    [XmlElement("D_CTX_Seg5.3",Order=2)]
    public string D_CTX_Seg53 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CTX_Seg6 {
    [XmlElement("D_CTX_Seg6.1",Order=0)]
    public string D_CTX_Seg61 {get; set;}
    [XmlElement("D_CTX_Seg6.2",Order=1)]
    public string D_CTX_Seg62 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CTX_BU {
    [XmlElement("C_CTX_BU1",Order=0)]
    public List<C_CTX_BU1> C_CTX_BU1 {get; set;}
    [XmlElement(Order=1)]
    public string D_CTX_BU2 {get; set;}
    [XmlElement(Order=2)]
    public string D_CTX_BU3 {get; set;}
    [XmlElement(Order=3)]
    public string D_CTX_BU4 {get; set;}
    [XmlElement(Order=4)]
    public C_CTX_BU5 C_CTX_BU5 {get; set;}
    [XmlElement(Order=5)]
    public C_CTX_BU6 C_CTX_BU6 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CTX_BU1 {
    [XmlElement("D_CTX_BU1.1",Order=0)]
    public X12_ID_9999_2 D_CTX_BU11 {get; set;}
    [XmlElement("D_CTX_BU1.2",Order=1)]
    public string D_CTX_BU12 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_9999_2 {
        TRN02,
        NM109,
        [XmlEnum("PATIENT NAME NM109")]
        PATIENTNAMENM109,
        [XmlEnum("SUBSCRIBER NAME NM109")]
        SUBSCRIBERNAMENM109,
        ENT01,
        [XmlEnum("SUBSCRIBER NUMBER REF02")]
        SUBSCRIBERNUMBERREF02,
        CLM01,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CTX_BU5 {
    [XmlElement("D_CTX_BU5.1",Order=0)]
    public string D_CTX_BU51 {get; set;}
    [XmlElement("D_CTX_BU5.2",Order=1)]
    public string D_CTX_BU52 {get; set;}
    [XmlElement("D_CTX_BU5.3",Order=2)]
    public string D_CTX_BU53 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CTX_BU6 {
    [XmlElement("D_CTX_BU6.1",Order=0)]
    public string D_CTX_BU61 {get; set;}
    [XmlElement("D_CTX_BU6.2",Order=1)]
    public string D_CTX_BU62 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class G_TS999_2110 {
    [XmlElement(Order=0)]
    public S_IK4 S_IK4 {get; set;}
    [XmlElement("S_CTX_Ele",Order=1)]
    public List<S_CTX_Ele> S_CTX_Ele {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_IK4 {
    [XmlElement(Order=0)]
    public C_IK41 C_IK41 {get; set;}
    [XmlElement(Order=1)]
    public string D_IK42 {get; set;}
    [XmlElement(Order=2)]
    public string D_IK43 {get; set;}
    [XmlElement(Order=3)]
    public string D_IK44 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_IK41 {
    [XmlElement("D_IK41.1",Order=0)]
    public string D_IK411 {get; set;}
    [XmlElement("D_IK41.2",Order=1)]
    public string D_IK412 {get; set;}
    [XmlElement("D_IK41.3",Order=2)]
    public string D_IK413 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_CTX_Ele {
    [XmlElement("C_CTX_Ele1",Order=0)]
    public List<C_CTX_Ele1> C_CTX_Ele1 {get; set;}
    [XmlElement(Order=1)]
    public X12_ID_721 D_CTX_Ele2 {get; set;}
    [XmlElement(Order=2)]
    public string D_CTX_Ele3 {get; set;}
    [XmlElement(Order=3)]
    public string D_CTX_Ele4 {get; set;}
    [XmlElement(Order=4)]
    public C_CTX_Ele5 C_CTX_Ele5 {get; set;}
    [XmlElement(Order=5)]
    public C_CTX_Ele6 C_CTX_Ele6 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CTX_Ele1 {
    [XmlElement("D_CTX_Ele1.1",Order=0)]
    public X12_ID_9999 D_CTX_Ele11 {get; set;}
    [XmlElement("D_CTX_Ele1.2",Order=1)]
    public string D_CTX_Ele12 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CTX_Ele5 {
    [XmlElement("D_CTX_Ele5.1",Order=0)]
    public string D_CTX_Ele51 {get; set;}
    [XmlElement("D_CTX_Ele5.2",Order=1)]
    public string D_CTX_Ele52 {get; set;}
    [XmlElement("D_CTX_Ele5.3",Order=2)]
    public string D_CTX_Ele53 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class C_CTX_Ele6 {
    [XmlElement("D_CTX_Ele6.1",Order=0)]
    public string D_CTX_Ele61 {get; set;}
    [XmlElement("D_CTX_Ele6.2",Order=1)]
    public string D_CTX_Ele62 {get; set;}
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_IK5 {
    [XmlElement(Order=0)]
    public X12_ID_717 D_IK501 {get; set;}
    [XmlElement(Order=1)]
    public string D_IK502 {get; set;}
    [XmlElement(Order=2)]
    public string D_IK503 {get; set;}
    [XmlElement(Order=3)]
    public string D_IK504 {get; set;}
    [XmlElement(Order=4)]
    public string D_IK505 {get; set;}
    [XmlElement(Order=5)]
    public string D_IK506 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_717 {
        A,
        E,
        M,
        R,
        W,
        X,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_AK9 {
    [XmlElement(Order=0)]
    public X12_ID_715 D_AK901 {get; set;}
    [XmlElement(Order=1)]
    public string D_AK902 {get; set;}
    [XmlElement(Order=2)]
    public string D_AK903 {get; set;}
    [XmlElement(Order=3)]
    public string D_AK904 {get; set;}
    [XmlElement(Order=4)]
    public string D_AK905 {get; set;}
    [XmlElement(Order=5)]
    public string D_AK906 {get; set;}
    [XmlElement(Order=6)]
    public string D_AK907 {get; set;}
    [XmlElement(Order=7)]
    public string D_AK908 {get; set;}
    [XmlElement(Order=8)]
    public string D_AK909 {get; set;}
    }
    
    [XmlType(Namespace="www.edifabric.com/x12", AnonymousType=true)]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public enum X12_ID_715 {
        A,
        E,
        M,
        P,
        R,
        W,
        X,
    }
    
    [XmlType(AnonymousType=true, Namespace="www.edifabric.com/x12")]
    [XmlRoot(Namespace="www.edifabric.com/x12", IsNullable=false)]
    public class S_SE {
    [XmlElement(Order=0)]
    public string D_SE01 {get; set;}
    [XmlElement(Order=1)]
    public string D_SE02 {get; set;}
    }
}
