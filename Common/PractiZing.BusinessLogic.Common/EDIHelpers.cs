using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PractiZing.BusinessLogic.Common
{
    public static class EDIHelpers277
    {
        static string a_delimeter = string.Empty;
        static string b_delimeter = string.Empty;
        static string c_delimeter = string.Empty;
        static string d_delimeter = string.Empty;

        public static Dictionary<string, string> ClaimStatusCodes()
        {
            return new Dictionary<string, string>()
      {
        {
          "0",
          "Cannot Provide Further Status Electronically"
        },
        {
          "1",
          "For More Detailed Information, See Remittance Advice"
        },
        {
          "2",
          "More Detailed Information In Letter"
        },
        {
          "3",
          "Claim Has Been Adjudicated And Is Awaiting Payment Cycle"
        },
        {
          "4",
          "This Is A Subsequent Request For Information From The Original Request"
        },
        {
          "5",
          "This Is A Final Request For Information"
        },
        {
          "6",
          "Balance Due From The Subscriber"
        },
        {
          "7",
          "Claim May Be Reconsidered At A Future Date"
        },
        {
          "8",
          "No Payment Due To Contract/Plan Provisions"
        },
        {
          "9",
          "No Payment Will Be Made For This Claim"
        },
        {
          "10",
          "All Originally Submitted Procedure Codes Have Been Combined"
        },
        {
          "11",
          "Some Originally Submitted Procedure Codes Have Been Combined"
        },
        {
          "12",
          "One Or More Originally Submitted Procedure Codes Have Been Combined"
        },
        {
          "13",
          "All Originally Submitted Procedure Codes Have Been Modified"
        },
        {
          "14",
          "Some All Originally Submitted Procedure Codes Have Been Modified"
        },
        {
          "15",
          "One Or More Originally Submitted Procedure Code Have Been Modified"
        },
        {
          "16",
          "Claim/Encounter Has Been Forwarded To Entity"
        },
        {
          "17",
          "Claim/Encounter Has Been Forwarded By Third Party Entity To Entity"
        },
        {
          "18",
          "Entity Received Claim/Encounter, But Returned Invalid Status"
        },
        {
          "19",
          "Claim Has Been Received"
        },
        {
          "20",
          "Accepted For Processing"
        },
        {
          "21",
          "Missing Or Invalid Information"
        },
        {
          "23",
          "Returned To Entity"
        },
        {
          "24",
          "Entity Not Approved As An Electronic Submitter"
        },
        {
          "25",
          "Entity Not Approved"
        },
        {
          "26",
          "Entity Not Found"
        },
        {
          "27",
          "Policy Canceled"
        },
        {
          "28",
          "Claim Submitted To Wrong Payer"
        },
        {
          "29",
          "Subscriber And Policy Number/Contract Number Mismatched"
        },
        {
          "30",
          "Subscriber And Subscriber Id Mismatched"
        },
        {
          "31",
          "Subscriber And Policyholder Name Mismatched"
        },
        {
          "32",
          "Subscriber And Policy Number/Contract Number Not Found"
        },
        {
          "33",
          "Subscriber And Subscriber Id Not Found"
        },
        {
          "34",
          "Subscriber And Policyholder Name Not Found"
        },
        {
          "35",
          "Claim/Encounter Not Found"
        },
        {
          "37",
          "Predetermination Is On File, Awaiting Completion Of Services"
        },
        {
          "38",
          "Awaiting Next Periodic Adjudication Cycle"
        },
        {
          "39",
          "Charges For Pregnancy Deferred Until Delivery"
        },
        {
          "40",
          "Waiting For Final Approval"
        },
        {
          "41",
          "Special Handling Required At Payer Site"
        },
        {
          "44",
          "Charges Pending Provider Audit"
        },
        {
          "45",
          "Awaiting Benefit Determination"
        },
        {
          "46",
          "Internal Review/Audit"
        },
        {
          "47",
          "Internal Review/Audit - Partial Payment Made"
        },
        {
          "48",
          "Referral/Authorization"
        },
        {
          "49",
          "Pending Provider Accreditation Review"
        },
        {
          "50",
          "Claim Waiting For Internal Provider Verification"
        },
        {
          "51",
          "Investigating Occupational Illness/Accident"
        },
        {
          "52",
          "Investigating Existence Of Other Insurance Coverage"
        },
        {
          "53",
          "Claim Being Researched For Insured Id/Group Policy Number Error"
        },
        {
          "54",
          "Duplicate Of A Previously Processed Claim/Line"
        },
        {
          "55",
          "Claim Assigned To An Approver/Analyst"
        },
        {
          "56",
          "Awaiting Eligibility Determination"
        },
        {
          "57",
          "Pending Cobra Information Requested"
        },
        {
          "59",
          "Information Was Requested By A Non-Electronic Method"
        },
        {
          "60",
          "Information Was Requested By An Electronic Method"
        },
        {
          "61",
          "Eligibility For Extended Benefits"
        },
        {
          "64",
          "Re-Pricing Information"
        },
        {
          "65",
          "Claim/Line Has Been Paid"
        },
        {
          "66",
          "Payment Reflects Usual And Customary Charges"
        },
        {
          "67",
          "Payment Made In Full"
        },
        {
          "68",
          "Partial Payment Made For This Claim"
        },
        {
          "69",
          "Payment Reflects Plan Provisions"
        },
        {
          "70",
          "Payment Reflects Contract Provisions"
        },
        {
          "71",
          "Periodic Installment Released"
        },
        {
          "72",
          "Claim Contains Split Payment"
        },
        {
          "73",
          "Payment Made To Entity, Assignment Of Benefits Not On File"
        },
        {
          "78",
          "Duplicate Of An Existing Claim/Line, Awaiting Processing"
        },
        {
          "81",
          "Contract/Plan Does Not Cover Pre-Existing Conditions"
        },
        {
          "83",
          "No Coverage For Newborns"
        },
        {
          "84",
          "Service Not Authorized"
        },
        {
          "85",
          "Entity Not Primary"
        },
        {
          "86",
          "Diagnosis And Patient Gender Mismatch"
        },
        {
          "87",
          "Denied: Entity Not Found"
        },
        {
          "88",
          "Entity Not Eligible For Benefits For Submitted Dates Of Service"
        },
        {
          "89",
          "Entity Not Eligible For Dental Benefits For Submitted Dates Of Service"
        },
        {
          "90",
          "Entity Not Eligible For Medical Benefits For Submitted Dates Of Service"
        },
        {
          "91",
          "Entity Not Eligible/Not Approved For Dates Of Service"
        },
        {
          "92",
          "Entity Does Not Meet Dependent Or Student Qualification"
        },
        {
          "93",
          "Entity Is Not Selected Primary Care Provider"
        },
        {
          "94",
          "Entity Not Referred By Selected Primary Care Provider"
        },
        {
          "95",
          "Requested Additional Information Not Received"
        },
        {
          "96",
          "No Agreement With Entity"
        },
        {
          "97",
          "Patient Eligibility Not Found With Entity"
        },
        {
          "98",
          "Charges Applied To Deductible"
        },
        {
          "99",
          "Pre-Treatment Review"
        },
        {
          "100",
          "Pre-Certification Penalty Taken"
        },
        {
          "101",
          "Claim Was Processed As Adjustment To Previous Claim"
        },
        {
          "102",
          "Newborn's Charges Processed On Mother's Claim"
        },
        {
          "103",
          "Claim Combined With Other Claim(S)"
        },
        {
          "104",
          "Processed According To Plan Provisions"
        },
        {
          "105",
          "Claim/Line Is Capitated"
        },
        {
          "106",
          "This Amount Is Not Entity's Responsibility"
        },
        {
          "107",
          "Processed According To Contract Provisions"
        },
        {
          "108",
          "Coverage Has Been Canceled For This Entity"
        },
        {
          "109",
          "Entity Not Eligible"
        },
        {
          "110",
          "Claim Requires Pricing Information"
        },
        {
          "111",
          "At The Policyholder's Request These Claims Cannot Be Submitted Electronically"
        },
        {
          "112",
          "Policyholder Processes Their Own Claims"
        },
        {
          "113",
          "Cannot Process Individual Insurance Policy Claims"
        },
        {
          "114",
          "Claim/Service Should Be Processed By Entity"
        },
        {
          "115",
          "Cannot Process Hmo Claims"
        },
        {
          "116",
          "Claim Submitted To Incorrect Payer"
        },
        {
          "117",
          "Claim Requires Signature-On-File Indicator"
        },
        {
          "118",
          "Tpo R Claim/Line Because Payer Name Is Missing"
        },
        {
          "119",
          "Tpo R Claim/Line Because Certification Information Is Missing"
        },
        {
          "120",
          "Tpo R Claim/Line Because Claim Does Not Contain Enough Information"
        },
        {
          "121",
          "Service Line Number Greater Than Maximum Allowable For Payer"
        },
        {
          "122",
          "Missing/Invalid Data Prevents Payer From Processing Claim"
        },
        {
          "123",
          "Additional Information Requested From Entity"
        },
        {
          "124",
          "Entity's Name, Address, Phone And Id Number"
        },
        {
          "125",
          "Entity's Name"
        },
        {
          "126",
          "Entity's Address"
        },
        {
          "127",
          "Entity's Communication Number"
        },
        {
          "128",
          "Entity's Tax Id"
        },
        {
          "129",
          "Entity's Blue Cross Provider Id"
        },
        {
          "130",
          "Entity's Blue Shield Provider Id"
        },
        {
          "131",
          "Entity's Medicare Provider Id"
        },
        {
          "132",
          "Entity's Medicaid Provider Id"
        },
        {
          "133",
          "Entity's Upin"
        },
        {
          "134",
          "Entity's Champus Provider Id"
        },
        {
          "135",
          "Entity's Commercial Provider Id"
        },
        {
          "136",
          "Entity's Health Industry Id Number"
        },
        {
          "137",
          "Entity's Plan Network Id"
        },
        {
          "138",
          "Entity's Site Id "
        },
        {
          "139",
          "Entity's Health Maintenance Provider Id (Hmo)"
        },
        {
          "140",
          "Entity's Preferred Provider Organization Id (Ppo)"
        },
        {
          "141",
          "Entity's Administrative Services Organization Id (Aso)"
        },
        {
          "142",
          "Entity's License/Certification Number"
        },
        {
          "143",
          "Entity's State License Number"
        },
        {
          "144",
          "Entity's Specialty License Number"
        },
        {
          "145",
          "Entity's Specialty/Taxonomy Code"
        },
        {
          "146",
          "Entity's Anesthesia License Number"
        },
        {
          "147",
          "Entity's Qualification Degree/Designation (E.G. Rn,Phd,Md)"
        },
        {
          "148",
          "Entity's Social Security Number"
        },
        {
          "149",
          "Entity's Employer Id"
        },
        {
          "150",
          "Entity's Drug Enforcement Agency (Dea) Number"
        },
        {
          "152",
          "Pharmacy Processor Number"
        },
        {
          "153",
          "Entity's Id Number"
        },
        {
          "154",
          "Relationship Of Surgeon   Surgeon"
        },
        {
          "155",
          "Entity's Relationship To Patient"
        },
        {
          "156",
          "Patient Relationship To Subscriber"
        },
        {
          "157",
          "Entity's Gender"
        },
        {
          "158",
          "Entity's Date Of Birth"
        },
        {
          "159",
          "Entity's Date Of Death"
        },
        {
          "160",
          "Entity's Marital Status"
        },
        {
          "161",
          "Entity's Employment Status"
        },
        {
          "162",
          "Entity's Health Insurance Claim Number (Hicn)"
        },
        {
          "163",
          "Entity's Policy/Group Number"
        },
        {
          "164",
          "Entity's Contract/Member Number"
        },
        {
          "165",
          "Entity's Employer Name, Address And Phone"
        },
        {
          "166",
          "Entity's Employer Name"
        },
        {
          "167",
          "Entity's Employer Address"
        },
        {
          "168",
          "Entity's Employer Phone Number"
        },
        {
          "169",
          "Entity's Employer Id"
        },
        {
          "170",
          "Entity's Employee Id"
        },
        {
          "171",
          "Other Insurance Coverage Information (Health, Liability, Auto, Etc.)"
        },
        {
          "172",
          "Other Employer Name, Address And Telephone Number"
        },
        {
          "173",
          "Entity's Name, Address, Phone, Gender, Dob, Marital Status, Employment Status And Relation To Subscriber"
        },
        {
          "174",
          "Entity's Student Status"
        },
        {
          "175",
          "Entity's School Name"
        },
        {
          "176",
          "Entity's School Address"
        },
        {
          "177",
          "Transplant Recipient's Name, Date Of Birth, Gender, Relationship To Insured"
        },
        {
          "178",
          "Submitted Charges"
        },
        {
          "179",
          "Outside Lab Charges"
        },
        {
          "180",
          "Hospital S Semi-Private Room Rate"
        },
        {
          "181",
          "Hospital S Room Rate"
        },
        {
          "182",
          "Allowable/Paid From Other Entities Coverage "
        },
        {
          "183",
          "Amount Entity Has Paid"
        },
        {
          "184",
          "Purchase Price For The Rented Durable Medical Equipment"
        },
        {
          "185",
          "Rental Price For Durable Medical Equipment"
        },
        {
          "186",
          "Purchase And Rental Price Of Durable Medical Equipment"
        },
        {
          "187",
          "Date(S) Of Service"
        },
        {
          "188",
          "Statement From-Through Dates"
        },
        {
          "189",
          "Facility Admission Date"
        },
        {
          "190",
          "Facility Discharge Date"
        },
        {
          "191",
          "Date Of Last Menstrual Period (Lmp)"
        },
        {
          "192",
          "Date Of First Service For Current Series/Symptom/Illness"
        },
        {
          "193",
          "First Consultation/Evaluation Date"
        },
        {
          "194",
          "Confinement Dates"
        },
        {
          "195",
          "Unable To Work Dates/Disability Dates"
        },
        {
          "196",
          "Return To Work Dates"
        },
        {
          "197",
          "Effective Coverage Date(S)"
        },
        {
          "198",
          "Medicare Effective Date"
        },
        {
          "199",
          "Date Of Conception And Expected Date Of Delivery"
        },
        {
          "200",
          "Date Of Equipment Return"
        },
        {
          "201",
          "Date Of Dental Appliance Prior Placement"
        },
        {
          "202",
          "Date Of Dental Prior Replacement/Reason For Replacement"
        },
        {
          "203",
          "Date Of Dental Appliance Placed"
        },
        {
          "204",
          "Date Dental Canal(S) Opened And Date Service Completed"
        },
        {
          "205",
          "Date(S) Dental Root Canal Therapy Previously Performed"
        },
        {
          "206",
          "Most Recent Date Of Curettage, Root Planing, Or Periodontal Surgery"
        },
        {
          "207",
          "Dental Impression And Seating Date"
        },
        {
          "208",
          "Most Recent Date Pacemaker Was Implanted"
        },
        {
          "209",
          "Most Recent Pacemaker Battery Change Date"
        },
        {
          "210",
          "Date Of The Last X-Ray"
        },
        {
          "211",
          "Date(S) Of Dialysis Training Provided To Patient"
        },
        {
          "212",
          "Date Of Last Routine Dialysis"
        },
        {
          "213",
          "Date Of First Routine Dialysis"
        },
        {
          "214",
          "Original Date Of Prescription/Orders/Referral"
        },
        {
          "215",
          "Date Of Tooth Extraction/Evolution"
        },
        {
          "216",
          "Drug Information"
        },
        {
          "217",
          "Drug Name, Strength And Dosage Form"
        },
        {
          "218",
          "Ndc Number"
        },
        {
          "219",
          "Prescription Number"
        },
        {
          "220",
          "Drug Product Id Number"
        },
        {
          "221",
          "Drug Days Supply And Dosage"
        },
        {
          "222",
          "Drug Dispensing Units And Average Wholesale Price (Awp)"
        },
        {
          "223",
          "Route Of Drug/Myelogram Administration"
        },
        {
          "224",
          "Anatomical Location For Joint Injection"
        },
        {
          "225",
          "Anatomical Location"
        },
        {
          "226",
          "Joint Injection Site"
        },
        {
          "227",
          "Hospital Information"
        },
        {
          "228",
          "Type Of Bill For Ub Claim"
        },
        {
          "229",
          "Hospital Admission Source"
        },
        {
          "230",
          "Hospital Admission Hour"
        },
        {
          "231",
          "Hospital Admission Type"
        },
        {
          "232",
          "Admitting Diagnosis"
        },
        {
          "233",
          "Hospital Discharge Hour"
        },
        {
          "234",
          "Patient Discharge Status"
        },
        {
          "235",
          "Units Of Blood Furnished"
        },
        {
          "236",
          "Units Of Blood Replaced"
        },
        {
          "237",
          "Units Of Deductible Blood"
        },
        {
          "238",
          "Separate Claim For Mother/Baby Charges"
        },
        {
          "239",
          "Dental Information"
        },
        {
          "240",
          "Tooth Surface(S) Involved"
        },
        {
          "241",
          "List Of All Missing Teeth (Upper And Lower)"
        },
        {
          "242",
          "Tooth Numbers, Surfaces, And/Or Quadrants Involved"
        },
        {
          "243",
          "Months Of Dental Treatment Remaining"
        },
        {
          "244",
          "Tooth Number Or Letter"
        },
        {
          "245",
          "Dental Quadrant/Arch"
        },
        {
          "246",
          "Total Orthodontic Service Fee, Initial Appliance Fee, Monthly Fee, Length Of Service"
        },
        {
          "247",
          "Line Information"
        },
        {
          "248",
          "Accident Date, State, Description And Cause"
        },
        {
          "249",
          "Place Of Service"
        },
        {
          "250",
          "Type Of Service"
        },
        {
          "251",
          "Total Anesthesia Minutes"
        },
        {
          "252",
          "Entity's Authorization/Certification Number. "
        },
        {
          "253",
          "Procedure/Revenue Code For Service(S) Rendered"
        },
        {
          "254",
          "Principal Diagnosis Code"
        },
        {
          "255",
          "Diagnosis Code"
        },
        {
          "256",
          "Drg Code(S)"
        },
        {
          "257",
          "Adsm-Iii-R Code For Services Rendered"
        },
        {
          "258",
          "Days/Units For Procedure/Revenue Code"
        },
        {
          "259",
          "Frequency Of Service"
        },
        {
          "260",
          "Length Of Medical Necessity, Including Begin Date"
        },
        {
          "261",
          "Obesity Measurements"
        },
        {
          "262",
          "Type Of Surgery/Service For Which Anesthesia Was Administered"
        },
        {
          "263",
          "Length Of Time For Services Rendered"
        },
        {
          "264",
          "Number Of Liters/Minute   Hours/Day For Respiratory Support"
        },
        {
          "265",
          "Number Of Lesions Excised"
        },
        {
          "266",
          "Facility Point Of Origin And Destination - Ambulance"
        },
        {
          "267",
          "Number Of Miles Patient Was Transported"
        },
        {
          "268",
          "Location Of Durable Medical Equipment Use"
        },
        {
          "269",
          "Length/Size Of Laceration/Tumor"
        },
        {
          "270",
          "Subluxation Location"
        },
        {
          "271",
          "Number Of Spine Segments"
        },
        {
          "272",
          "Oxygen Contents For Oxygen System Rental"
        },
        {
          "273",
          "Weight"
        },
        {
          "274",
          "Height"
        },
        {
          "275",
          "Claim"
        },
        {
          "276",
          "Ub04/Hcfa-1450/1500 Claim Form"
        },
        {
          "277",
          "Paper Claim"
        },
        {
          "278",
          "Signed Claim Form"
        },
        {
          "279",
          "Claim/Service Must Be Itemized"
        },
        {
          "280",
          "Itemized Claim By Provider"
        },
        {
          "281",
          "Related Confinement Claim"
        },
        {
          "282",
          "Copy Of Prescription"
        },
        {
          "283",
          "Medicare Entitlement Information Is Required To Determine Primary Coverage"
        },
        {
          "284",
          "Copy Of Medicare Id Card"
        },
        {
          "285",
          "Vouchers/Explanation Of Benefits (Eob)"
        },
        {
          "286",
          "Other Payer's Explanation Of Benefits / Payment Information"
        },
        {
          "287",
          "Medical Necessity For Service"
        },
        {
          "288",
          "Hospital Late Charges"
        },
        {
          "289",
          "Reason For Late Discharge"
        },
        {
          "290",
          "Pre-Existing Information"
        },
        {
          "291",
          "Reason For Termination Of Pregnancy"
        },
        {
          "292",
          "Purpose Of Family Conference/Therapy"
        },
        {
          "293",
          "Reason For Physical Therapy"
        },
        {
          "294",
          "Supporting Documentation. "
        },
        {
          "295",
          "Attending Physician Report"
        },
        {
          "296",
          "Nurse's Notes"
        },
        {
          "297",
          "Medical Notes/Report"
        },
        {
          "298",
          "Operative Report"
        },
        {
          "299",
          "Emergency Room Notes/Report"
        },
        {
          "300",
          "Lab/Test Report/Notes/Results"
        },
        {
          "301",
          "Mri Report"
        },
        {
          "302",
          "Refer To Codes 300 For Lab Notes And 311 For Pathology Notes"
        },
        {
          "303",
          "Physical Therapy Notes"
        },
        {
          "304",
          "Reports For Service"
        },
        {
          "305",
          "Radiology/X-Ray Reports And/Or Interpretation"
        },
        {
          "306",
          "Detailed Description Of Service"
        },
        {
          "307",
          "Narrative With Pocket Depth Chart"
        },
        {
          "308",
          "Discharge Summary"
        },
        {
          "309",
          "Code Was Duplicate Of Code 299"
        },
        {
          "310",
          "Progress Notes For The Six Months Prior To Statement Date"
        },
        {
          "311",
          "Pathology Notes/Report"
        },
        {
          "312",
          "Dental Charting"
        },
        {
          "313",
          "Bridgework Information"
        },
        {
          "314",
          "Dental Records For This Service"
        },
        {
          "315",
          "Past Perio Treatment History"
        },
        {
          "316",
          "Complete Medical History"
        },
        {
          "317",
          "Patient's Medical Records"
        },
        {
          "318",
          "X-Rays/Radiology Films"
        },
        {
          "319",
          "Pre/Post-Operative X-Rays/Photographs"
        },
        {
          "320",
          "Study Models"
        },
        {
          "321",
          "Radiographs Or Models"
        },
        {
          "322",
          "Recent Full Mouth X-Rays"
        },
        {
          "323",
          "Study Models, X-Rays, And/Or Narrative"
        },
        {
          "324",
          "Recent X-Ray Of Treatment Area And/Or Narrative"
        },
        {
          "325",
          "Recent Fm X-Rays And/Or Narrative"
        },
        {
          "326",
          "Copy Of Transplant Acquisition Invoice"
        },
        {
          "327",
          "Periodontal Case Type Diagnosis And Recent Pocket Depth Chart With Narrative"
        },
        {
          "328",
          "Speech Therapy Notes"
        },
        {
          "329",
          "Exercise Notes"
        },
        {
          "330",
          "Occupational Notes"
        },
        {
          "331",
          "History And Physical"
        },
        {
          "332",
          "Authorization/Certification (Include Period Covered)"
        },
        {
          "333",
          "Patient Release Of Information Authorization"
        },
        {
          "334",
          "Oxygen Certification"
        },
        {
          "335",
          "Durable Medical Equipment Certification"
        },
        {
          "336",
          "Chiropractic Certification"
        },
        {
          "337",
          "Ambulance Certification/Documentation"
        },
        {
          "338",
          "Home Health Certification"
        },
        {
          "339",
          "Enteral/Parenteral Certification"
        },
        {
          "340",
          "Pacemaker Certification"
        },
        {
          "341",
          "Private Duty Nursing Certification"
        },
        {
          "342",
          "Podiatric Certification"
        },
        {
          "343",
          "Documentation That Facility Is State Licensed And Medicare Approved As A Surgical Facility"
        },
        {
          "344",
          "Documentation That Provider Of Physical Therapy Is Medicare Part B Approved"
        },
        {
          "345",
          "Treatment Plan For Service/Diagnosis"
        },
        {
          "346",
          "Proposed Treatment Plan For Next 6 Months"
        },
        {
          "347",
          "Refer To Code 345 For Treatment Plan And Code 282 For Prescription"
        },
        {
          "348",
          "Chiropractic Treatment Plan"
        },
        {
          "349",
          "Psychiatric Treatment Plan"
        },
        {
          "350",
          "Speech Pathology Treatment Plan"
        },
        {
          "351",
          "Physical/Occupational Therapy Treatment Plan"
        },
        {
          "352",
          "Duration Of Treatment Plan"
        },
        {
          "353",
          "Orthodontics Treatment Plan"
        },
        {
          "354",
          "Treatment Plan For Replacement Of Remaining Missing Teeth"
        },
        {
          "355",
          "Has Claim Been Paid?"
        },
        {
          "356",
          "Was Blood Furnished?"
        },
        {
          "357",
          "Has Or Will Blood Be Replaced?"
        },
        {
          "358",
          "Does Provider Accept Assignment Of Benefits?"
        },
        {
          "359",
          "Is There A Release Of Information Signature On File?"
        },
        {
          "360",
          "Benefits Assignment Certification Indicator"
        },
        {
          "361",
          "Is There Other Insurance?"
        },
        {
          "362",
          "Is The Dental Patient Covered By Medical Insurance?"
        },
        {
          "363",
          "Possible Workers Compensation"
        },
        {
          "364",
          "Is Accident/Illness/Condition Employment Related?"
        },
        {
          "365",
          "Is Service The Result Of An Accident?"
        },
        {
          "366",
          "Is Injury Due To Auto Accident?"
        },
        {
          "367",
          "Is Service Performed For A Recurring Condition Or New Condition?"
        },
        {
          "368",
          "Is Medical Doctor (Md) Or Doctor Of Osteopath (Do) On Staff Of This Facility?"
        },
        {
          "369",
          "Does Patient Condition Preclude Use Of Ordinary Bed?"
        },
        {
          "370",
          "Can Patient Operate Controls Of Bed?"
        },
        {
          "371",
          "Is Patient Confined To Room?"
        },
        {
          "372",
          "Is Patient Confined To Bed?"
        },
        {
          "373",
          "Is Patient An Insulin Diabetic?"
        },
        {
          "374",
          "Is Prescribed Lenses A Result Of Cataract Surgery?"
        },
        {
          "375",
          "Was Refraction Performed?"
        },
        {
          "376",
          "Was Charge For Ambulance For A Round-Trip?"
        },
        {
          "377",
          "Was Durable Medical Equipment Purchased New Or Used?"
        },
        {
          "378",
          "Is Pacemaker Temporary Or Permanent?"
        },
        {
          "379",
          "Were Services Performed Supervised By A Physician?"
        },
        {
          "380",
          "Crna Supervision/Medical Direction"
        },
        {
          "381",
          "Is Drug Generic?"
        },
        {
          "382",
          "Did Provider Authorize Generic Or Brand Name Dispensing?"
        },
        {
          "383",
          "Nerve Block Use (Surgery Vs. Pain Management)"
        },
        {
          "384",
          "Is Prosthesis/Crown/Inlay Placement An Initial Placement Or A Replacement?"
        },
        {
          "385",
          "Is Appliance Upper Or Lower Arch  Appliance Fixed Or Removable?"
        },
        {
          "386",
          "Orthodontic Treatment/Purpose Indicator"
        },
        {
          "387",
          "Date Patient Last Examined By Entity"
        },
        {
          "388",
          "Date Post-Operative Care Assumed"
        },
        {
          "389",
          "Date Post-Operative Care Relinquished"
        },
        {
          "390",
          "Date Of Most Recent Medical Event Necessitating Service(S)"
        },
        {
          "391",
          "Date(S) Dialysis Conducted"
        },
        {
          "392",
          "Date(S) Of Blood Transfusion(S)"
        },
        {
          "393",
          "Date Of Previous Pacemaker Check"
        },
        {
          "394",
          "Date(S) Of Most Recent Hospitalization Related To Service"
        },
        {
          "395",
          "Date Entity Signed Certification/Recertification"
        },
        {
          "396",
          "Date Home Dialysis Began"
        },
        {
          "397",
          "Date Of Onset/Exacerbation Of Illness/Condition"
        },
        {
          "398",
          "Visual Field Test Results"
        },
        {
          "399",
          "Report Of Prior Testing Related To This Service, Including Dates"
        },
        {
          "400",
          "Claim Is Out Of Balance"
        },
        {
          "401",
          "Source Of Payment Is Not Valid"
        },
        {
          "402",
          "Amount Must Be Greater Than Zero"
        },
        {
          "403",
          "Entity Referral Notes/Orders/Prescription"
        },
        {
          "404",
          "Specific Findings, Complaints, Or Symptoms Necessitating Service"
        },
        {
          "405",
          "Summary Of Services"
        },
        {
          "406",
          "Brief Medical History As Related To Service(S)"
        },
        {
          "407",
          "Complications/Mitigating Circumstances"
        },
        {
          "408",
          "Initial Certification"
        },
        {
          "409",
          "Medication Logs/Records (Including Medication Therapy)"
        },
        {
          "410",
          "Explain Differences Between Treatment Plan And Patient's Condition"
        },
        {
          "411",
          "Medical Necessity For Non-Routine Service(S)"
        },
        {
          "412",
          "Medical Records To Substantiate Decision Of Non-Coverage"
        },
        {
          "413",
          "Explain/Justify Differences Between Treatment Plan And Services Rendered"
        },
        {
          "414",
          "Necessity For Concurrent Care (More Than One Physician Treating The Patient)"
        },
        {
          "415",
          "Justify Services Outside Composite Rate"
        },
        {
          "416",
          "Verification Of Patient's Ability To Retain And Use Information"
        },
        {
          "417",
          "Prior Testing, Including Result(S) And Date(S) As Related To Service(S)"
        },
        {
          "418",
          "Indicating Why Medications Cannot Be Taken Orally"
        },
        {
          "419",
          "Individual Test(S) Comprising The Panel And The Charges For Each Test"
        },
        {
          "420",
          "Name, Dosage And Medical Justification Of Contrast Material Used For Radiology Procedure"
        },
        {
          "421",
          "Medical Review Attachment/Information For Service(S)"
        },
        {
          "422",
          "Homebound Status"
        },
        {
          "423",
          "Prognosis"
        },
        {
          "424",
          "Statement Of Non-Coverage Including Itemized Bill"
        },
        {
          "425",
          "Itemize Non-Covered Services"
        },
        {
          "426",
          "All Current Diagnoses"
        },
        {
          "427",
          "Emergency Care Provided During Transport"
        },
        {
          "428",
          "Reason For Transport By Ambulance"
        },
        {
          "429",
          "Loaded Miles And Charges For Transport To Nearest Facility With Appropriate Services"
        },
        {
          "430",
          "Nearest Appropriate Facility"
        },
        {
          "431",
          "Patient's Condition / Functional Status At Time Of Service"
        },
        {
          "432",
          "Date Benefits Exhausted"
        },
        {
          "433",
          "Copy Of Patient Revocation Of Hospice Benefits"
        },
        {
          "434",
          "Reasons For More Than One Transfer Per Entitlement Period"
        },
        {
          "435",
          "Notice Of Admission"
        },
        {
          "436",
          "Short Term Goals"
        },
        {
          "437",
          "Long Term Goals"
        },
        {
          "438",
          "Number Of Patients Attending Session"
        },
        {
          "439",
          "Size, Depth, Amount, And Type Of Drainage Wounds"
        },
        {
          "440",
          "Why Non-Skilled Caregiver Has Not Been Taught Procedure"
        },
        {
          "441",
          "Entity Professional Qualification For Service(S)"
        },
        {
          "442",
          "Modalities Of Service"
        },
        {
          "443",
          "Initial Evaluation Report"
        },
        {
          "444",
          "Method Used To Obtain Test Sample"
        },
        {
          "445",
          "Explain Why Hearing Loss Not Correctable By Hearing Aid"
        },
        {
          "446",
          "Documentation From Prior Claim(S) Related To Service(S)"
        },
        {
          "447",
          "Plan Of Teaching"
        },
        {
          "448",
          "Invalid Billing Combination. See Stc12 For Details"
        },
        {
          "449",
          "Projected Date To Discontinue Service(S)"
        },
        {
          "450",
          "Awaiting Spend Down Determination"
        },
        {
          "451",
          "Preoperative And Post-Operative Diagnosis"
        },
        {
          "452",
          "Total Visits In Total Number Of Hours/Day And Total Number Of Hours/Week"
        },
        {
          "453",
          "Procedure Code Modifier(S) For Service(S) Rendered"
        },
        {
          "454",
          "Procedure Code For Services Rendered"
        },
        {
          "455",
          "Revenue Code For Services Rendered"
        },
        {
          "456",
          "Covered Day(S)"
        },
        {
          "457",
          "Non-Covered Day(S)"
        },
        {
          "458",
          "Coinsurance Day(S)"
        },
        {
          "459",
          "Lifetime Reserve Day(S)"
        },
        {
          "460",
          "Nubc Condition Code(S)"
        },
        {
          "461",
          "Nubc Occurrence Code(S) And Date(S)"
        },
        {
          "462",
          "Nubc Occurrence Span Code(S) And Date(S)"
        },
        {
          "463",
          "Nubc Value Code(S) And/Or Amount(S)"
        },
        {
          "464",
          "Payer Assigned Claim Control Number"
        },
        {
          "465",
          "Principal Procedure Code For Service(S) Rendered"
        },
        {
          "466",
          "Entity's Original Signature"
        },
        {
          "467",
          "Entity Signature Date"
        },
        {
          "468",
          "Patient Signature Source"
        },
        {
          "469",
          "Purchase Service Charge"
        },
        {
          "470",
          "Was Service Purchased From Another Entity?"
        },
        {
          "472",
          "Ambulance Run Sheet"
        },
        {
          "473",
          "Missing Or Invalid Lab Indicator"
        },
        {
          "474",
          "Procedure Code And Patient Gender Mismatch"
        },
        {
          "475",
          "Procedure Code Not Valid For Patient Age"
        },
        {
          "476",
          "Missing Or Invalid Units Of Service"
        },
        {
          "477",
          "Diagnosis Code Pointer Is Missing Or Invalid"
        },
        {
          "478",
          "Claim Submitter'S Identifier"
        },
        {
          "479",
          "Other Carrier Payer Id Is Missing Or Invalid"
        },
        {
          "480",
          "Entity's Claim Filing Indicator"
        },
        {
          "481",
          "Claim/Submission Format Is Invalid"
        },
        {
          "482",
          "Date Error, Century Missing"
        },
        {
          "483",
          "Maximum Coverage Amount Met Or Exceeded For Benefit Period"
        },
        {
          "484",
          "Business Application Currently Not Available"
        },
        {
          "485",
          "More Information Available Than Can Be Returned In Real Time Mode"
        },
        {
          "486",
          "Principal Procedure Date"
        },
        {
          "487",
          "Claim Not Found, Claim Should Have Been Submitted To/Through Entity"
        },
        {
          "488",
          "Diagnosis Code(S) For The Services Rendered"
        },
        {
          "490",
          "Other Procedure Code For Service(S) Rendered"
        },
        {
          "491",
          "Entity Not Eligible For Encounter Submission"
        },
        {
          "492",
          "Other Procedure Date"
        },
        {
          "493",
          "Version/Release/Industry Id Code Not Currently Supported By Information Holder"
        },
        {
          "494",
          "Real-Time Requests Not Supported By The Information Holder, Resubmit As Batch Request"
        },
        {
          "495",
          "Requests For Re-Adjudication Must Reference The Newly Assigned Payer Claim Number"
        },
        {
          "496",
          "Submitter Not Approved For Electronic Claim Submissions On Behalf Of This Entity"
        },
        {
          "497",
          "Sales Tax Not Paid"
        },
        {
          "498",
          "Maximum Leave Days Exhausted"
        },
        {
          "499",
          "No Rate On File With The Payer For This Service For This Entity"
        },
        {
          "500",
          "Entity's Postal/Zip Code"
        },
        {
          "501",
          "Entity's State/Province"
        },
        {
          "502",
          "Entity's City"
        },
        {
          "503",
          "Entity's Street Address"
        },
        {
          "504",
          "Entity's Last Name"
        },
        {
          "505",
          "Entity's First Name"
        },
        {
          "506",
          "Entity Is Changing Processor/Clearinghouse. Submit To The New Processor/Clearinghouse"
        },
        {
          "507",
          "Hcpcs"
        },
        {
          "508",
          "Icd9 Note: At Least One Other Status Code Is Required"
        },
        {
          "509",
          "External Cause Of Injury Code (E-Code)"
        },
        {
          "510",
          "Future Date. "
        },
        {
          "511",
          "Invalid Character. "
        },
        {
          "512",
          "Length Invalid For Receiver's Application System. "
        },
        {
          "513",
          "Hipps Rate Code For Services Rendered"
        },
        {
          "514",
          "Entity's Middle Name"
        },
        {
          "515",
          "Managed Care Review"
        },
        {
          "516",
          "Other Entity's Adjudication Or Payment/Remittance Date"
        },
        {
          "517",
          "Adjusted Repriced Claim Reference Number"
        },
        {
          "518",
          "Adjusted Repriced Line Item Reference Number"
        },
        {
          "519",
          "Adjustment Amount"
        },
        {
          "520",
          "Adjustment Quantity"
        },
        {
          "521",
          "Adjustment Reason Code"
        },
        {
          "522",
          "Anesthesia Modifying Units"
        },
        {
          "523",
          "Anesthesia Unit Count"
        },
        {
          "524",
          "Arterial Blood Gas Quantity"
        },
        {
          "525",
          "Begin Therapy Date"
        },
        {
          "526",
          "Bundled Or Unbundled Line Number"
        },
        {
          "527",
          "Certification Condition Indicator"
        },
        {
          "528",
          "Certification Period Projected Visit Count"
        },
        {
          "529",
          "Certification Revision Date"
        },
        {
          "530",
          "Claim Adjustment Indicator"
        },
        {
          "531",
          "Claim Disproportinate Share Amount"
        },
        {
          "532",
          "Claim Drg Amount"
        },
        {
          "533",
          "Claim Drg Outlier Amount"
        },
        {
          "534",
          "Claim Esrd Payment Amount"
        },
        {
          "535",
          "Claim Frequency Code"
        },
        {
          "536",
          "Claim Indirect Teaching Amount"
        },
        {
          "537",
          "Claim Msp Pass-Through Amount"
        },
        {
          "538",
          "Claim Or Encounter Identifier"
        },
        {
          "539",
          "Claim Pps Capital Amount"
        },
        {
          "540",
          "Claim Pps Capital Outlier Amount"
        },
        {
          "541",
          "Claim Submission Reason Code"
        },
        {
          "542",
          "Claim Total Denied Charge Amount"
        },
        {
          "543",
          "Clearinghouse Or Value Added Network Trace"
        },
        {
          "544",
          "Clinical Laboratory Improvement Amendment"
        },
        {
          "545",
          "Contract Amount"
        },
        {
          "546",
          "Contract Code"
        },
        {
          "547",
          "Contract Percentage"
        },
        {
          "548",
          "Contract Type Code"
        },
        {
          "549",
          "Contract Version Identifier"
        },
        {
          "550",
          "Coordination Of Benefits Code"
        },
        {
          "551",
          "Coordination Of Benefits Total Submitted Charge"
        },
        {
          "552",
          "Cost Report Day Count"
        },
        {
          "553",
          "Covered Amount"
        },
        {
          "554",
          "Date Claim Paid"
        },
        {
          "555",
          "Delay Reason Code"
        },
        {
          "556",
          "Demonstration Project Identifier"
        },
        {
          "557",
          "Diagnosis Date"
        },
        {
          "558",
          "Discount Amount"
        },
        {
          "559",
          "Document Control Identifier"
        },
        {
          "560",
          "Entity's Additional/Secondary Identifier"
        },
        {
          "561",
          "Entity's Contact Name"
        },
        {
          "562",
          "Entity's National Provider Identifier (Npi)"
        },
        {
          "563",
          "Entity's Tax Amount"
        },
        {
          "564",
          "Epsdt Indicator"
        },
        {
          "565",
          "Estimated Claim Due Amount"
        },
        {
          "566",
          "Exception Code"
        },
        {
          "567",
          "Facility Code Qualifier"
        },
        {
          "568",
          "Family Planning Indicator"
        },
        {
          "569",
          "Fixed Format Information"
        },
        {
          "570",
          "Free Form Message Text"
        },
        {
          "571",
          "Frequency Count"
        },
        {
          "572",
          "Frequency Period"
        },
        {
          "573",
          "Functional Limitation Code"
        },
        {
          "574",
          "Hcpcs Payable Amount Home Health"
        },
        {
          "575",
          "Homebound Indicator"
        },
        {
          "576",
          "Immunization Batch Number"
        },
        {
          "577",
          "Industry Code"
        },
        {
          "578",
          "Insurance Type Code"
        },
        {
          "579",
          "Investigational Device Exemption Identifier"
        },
        {
          "580",
          "Last Certification Date"
        },
        {
          "581",
          "Last Worked Date"
        },
        {
          "582",
          "Lifetime Psychiatric Days Count"
        },
        {
          "583",
          "Line Item Charge Amount"
        },
        {
          "584",
          "Line Item Control Number"
        },
        {
          "585",
          "Denied Charge Or Non-Covered Charge"
        },
        {
          "586",
          "Line Note Text"
        },
        {
          "587",
          "Measurement Reference Identification Code"
        },
        {
          "588",
          "Medical Record Number"
        },
        {
          "589",
          "Provider Accept Assignment Code"
        },
        {
          "590",
          "Medicare Coverage Indicator"
        },
        {
          "591",
          "Medicare Paid At 100% Amount"
        },
        {
          "592",
          "Medicare Paid At 80% Amount"
        },
        {
          "593",
          "Medicare Section 4081 Indicator"
        },
        {
          "594",
          "Mental Status Code"
        },
        {
          "595",
          "Monthly Treatment Count"
        },
        {
          "596",
          "Non-Covered Charge Amount"
        },
        {
          "597",
          "Non-Payable Professional Component Amount"
        },
        {
          "598",
          "Non-Payable Professional Component Billed Amount"
        },
        {
          "599",
          "Note Reference Code"
        },
        {
          "600",
          "Oxygen Saturation Qty"
        },
        {
          "601",
          "Oxygen Test Condition Code"
        },
        {
          "602",
          "Oxygen Test Date"
        },
        {
          "603",
          "Old Capital Amount"
        },
        {
          "604",
          "Originator Application Transaction Identifier"
        },
        {
          "605",
          "Orthodontic Treatment Months Count"
        },
        {
          "606",
          "Paid From Part A Medicare Trust Fund Amount"
        },
        {
          "607",
          "Paid From Part B Medicare Trust Fund Amount"
        },
        {
          "608",
          "Paid Service Unit Count"
        },
        {
          "609",
          "Participation Agreement"
        },
        {
          "610",
          "Patient Discharge Facility Type Code"
        },
        {
          "611",
          "Peer Review Authorization Number"
        },
        {
          "612",
          "Per Day Limit Amount"
        },
        {
          "613",
          "Physician Contact Date"
        },
        {
          "614",
          "Physician Order Date"
        },
        {
          "615",
          "Policy Compliance Code"
        },
        {
          "616",
          "Policy Name"
        },
        {
          "617",
          "Postage Claimed Amount"
        },
        {
          "618",
          "Pps-Capital Dsh Drg Amount"
        },
        {
          "619",
          "Pps-Capital Exception Amount"
        },
        {
          "620",
          "Pps-Capital Fsp Drg Amount"
        },
        {
          "621",
          "Pps-Capital Hsp Drg Amount"
        },
        {
          "622",
          "Pps-Capital Ime Amount"
        },
        {
          "623",
          "Pps-Operating Federal Specific Drg Amount"
        },
        {
          "624",
          "Pps-Operating Hospital Specific Drg Amount"
        },
        {
          "625",
          "Predetermination Of Benefits Identifier"
        },
        {
          "626",
          "Pregnancy Indicator"
        },
        {
          "627",
          "Pre-Tax Claim Amount"
        },
        {
          "628",
          "Pricing Methodology"
        },
        {
          "629",
          "Property Casualty Claim Number"
        },
        {
          "630",
          "Referring Clia Number"
        },
        {
          "631",
          "Reimbursement Rate"
        },
        {
          "632",
          "Reject Reason Code"
        },
        {
          "633",
          "Related Causes Code (Accident, Auto Accident, Employment)"
        },
        {
          "634",
          "Remark Code"
        },
        {
          "635",
          "Repriced Ambulatory Patient Group Code"
        },
        {
          "636",
          "Repriced Line Item Reference Number"
        },
        {
          "637",
          "Repriced Saving Amount"
        },
        {
          "638",
          "Repricing Per Diem Or Flat Rate Amount"
        },
        {
          "639",
          "Responsibility Amount"
        },
        {
          "640",
          "Sales Tax Amount"
        },
        {
          "641",
          "Service Adjudication Or Payment Date"
        },
        {
          "642",
          "Service Authorization Exception Code"
        },
        {
          "643",
          "Service Line Paid Amount"
        },
        {
          "644",
          "Service Line Rate"
        },
        {
          "645",
          "Service Tax Amount"
        },
        {
          "646",
          "Ship, Delivery Or Calendar Pattern Code"
        },
        {
          "647",
          "Shipped Date"
        },
        {
          "648",
          "Similar Illness Or Symptom Date"
        },
        {
          "649",
          "Skilled Nursing Facility Indicator"
        },
        {
          "650",
          "Special Program Indicator"
        },
        {
          "651",
          "State Industrial Accident Provider Number"
        },
        {
          "652",
          "Terms Discount Percentage"
        },
        {
          "653",
          "Test Performed Date"
        },
        {
          "654",
          "Total Denied Charge Amount"
        },
        {
          "655",
          "Total Medicare Paid Amount"
        },
        {
          "656",
          "Total Visits Projected This Certification Count"
        },
        {
          "657",
          "Total Visits Rendered Count"
        },
        {
          "658",
          "Treatment Code"
        },
        {
          "659",
          "Unit Or Basis For Measurement Code"
        },
        {
          "660",
          "Universal Product Number"
        },
        {
          "661",
          "Visits Prior To Recertification Date Count Cr702"
        },
        {
          "662",
          "X-Ray Availability Indicator"
        },
        {
          "663",
          "Entity's Group Name"
        },
        {
          "664",
          "Orthodontic Banding Date"
        },
        {
          "665",
          "Surgery Date"
        },
        {
          "666",
          "Surgical Procedure Code"
        },
        {
          "667",
          "Real-Time Requests Not Supported By The Information Holder, Do Not Resubmit"
        },
        {
          "668",
          "Missing Endodontics Treatment History And Prognosis"
        },
        {
          "669",
          "Dental Service Narrative Needed"
        },
        {
          "670",
          "Funds Applied From A Spending Account; Consumer Directed Cdhp, H S A"
        },
        {
          "671",
          "Funds May Be Available From A Spending Account; Consumer Directed Cdhp, H S A"
        },
        {
          "672",
          "Other Payer's Payment Information Is Out Of Balance"
        },
        {
          "673",
          "Patient Reason For Visit"
        },
        {
          "674",
          "Authorization Exceeded"
        },
        {
          "675",
          "Facility Admission Through Discharge Dates"
        },
        {
          "676",
          "Entity Possibly Compensated By Facility"
        },
        {
          "677",
          "Entity Not Affiliated"
        },
        {
          "678",
          "Revenue Code And Patient Gender Mismatch"
        },
        {
          "679",
          "Submit Newborn Services On Mothers Claim"
        },
        {
          "680",
          "Entity's Country"
        },
        {
          "681",
          "Claim Currency Not Supported"
        },
        {
          "682",
          "Cosmetic Procedure"
        },
        {
          "683",
          "Awaiting Associated Hospital Claims"
        },
        {
          "684",
          "Rejected. Syntax Error Noted For This Claim/Service/Inquiry"
        },
        {
          "685",
          "Claim Could Not Complete Adjudication In Real Time. Processing In A Batch Mode. Do Not Resubmit"
        },
        {
          "686",
          "The Claim/ Encounter Has Completed The Adjudication Cycle And The Entire Claim Has Been Voided"
        },
        {
          "687",
          "Claim Estimation Can Not Be Completed In Real Time. Do Not Resubmit"
        },
        {
          "688",
          "Present On Admission Indicator For Reported Diagnosis Code(S)"
        },
        {
          "689",
          "Entity Was Unable To Respond Within The Expected Time Frame"
        },
        {
          "690",
          "Multiple Claims Or Estimate Requests Cannot Be Processed In Real Time"
        },
        {
          "691",
          "Multiple Claim Status Requests Cannot Be Processed In Real Time"
        },
        {
          "692",
          "Contracted Funding Agreement-Subscriber Is Employed By The Provider Of Services"
        },
        {
          "693",
          "Amount Must Be Greater Than Or Equal To Zero"
        },
        {
          "694",
          "Amount Must Not Be Equal To Zero"
        },
        {
          "695",
          "Entity's Country Subdivision Code"
        },
        {
          "696",
          "Claim Adjustment Group Code"
        },
        {
          "697",
          "Invalid Decimal Precision. "
        },
        {
          "698",
          "Form Type Identification"
        },
        {
          "699",
          "Question/Response From Supporting Documentation Form"
        },
        {
          "700",
          "Icd10. Note: At Least One Other Status Code Is Required To Identify The Related Procedure Code Or Diagnosis"
        },
        {
          "701",
          "Initial Treatment Date"
        },
        {
          "702",
          "Repriced Claim Reference Number"
        },
        {
          "703",
          "Advanced Billing Concepts (Abc) Code"
        },
        {
          "704",
          "Claim Note Text"
        },
        {
          "705",
          "Repriced Allowed Amount"
        },
        {
          "706",
          "Repriced Approved Amount"
        },
        {
          "707",
          "Repriced Approved Ambulatory Patient Group Amount"
        },
        {
          "708",
          "Repriced Approved Revenue Code"
        },
        {
          "709",
          "Repriced Approved Service Unit Count"
        },
        {
          "710",
          "Line Adjudication Information. "
        },
        {
          "711",
          "Stretcher Purpose"
        },
        {
          "712",
          "Obstetric Additional Units"
        },
        {
          "713",
          "Patient Condition Description"
        },
        {
          "714",
          "Care Plan Oversight Number"
        },
        {
          "715",
          "Acute Manifestation Date"
        },
        {
          "716",
          "Repriced Approved Drg Code"
        },
        {
          "717",
          "This Claim Has Been Split For Processing"
        },
        {
          "718",
          "Claim/Service Not Submitted Within The Required Timeframe (Timely Filing)"
        },
        {
          "719",
          "Nubc Occurrence Code(S)"
        },
        {
          "720",
          "Nubc Occurrence Code Date(S)"
        },
        {
          "721",
          "Nubc Occurrence Span Code(S)"
        },
        {
          "722",
          "Nubc Occurrence Span Code Date(S)"
        },
        {
          "723",
          "Drug Days Supply"
        },
        {
          "724",
          "Drug Dosage"
        },
        {
          "725",
          "Nubc Value Code(S)"
        },
        {
          "726",
          "Nubc Value Code Amount(S)"
        },
        {
          "727",
          "Accident Date"
        },
        {
          "728",
          "Accident State"
        },
        {
          "729",
          "Accident Description"
        },
        {
          "730",
          "Accident Cause"
        },
        {
          "731",
          "Measurement Value/Test Result"
        },
        {
          "732",
          "Information Submitted Inconsistent With Billing Guidelines. "
        },
        {
          "733",
          "Prefix For Entity's Contract/Member Number"
        },
        {
          "734",
          "Verifying Premium Payment"
        },
        {
          "735",
          "This Service/Claim Is Included In The Allowance For Another Service Or Claim"
        },
        {
          "736",
          "A Related Or Qualifying Service/Claim Has Not Been Received/Adjudicated"
        },
        {
          "737",
          "Current Dental Terminology (Cdt) Code"
        },
        {
          "738",
          "Home Infusion Edi Coalition (Heic) Product/Service Code"
        },
        {
          "739",
          "Jurisdiction Specific Procedure Or Supply Code"
        },
        {
          "740",
          "Drop-Off Location"
        },
        {
          "741",
          "Entity Must Be A Person"
        },
        {
          "742",
          "Payer Responsibility Sequence Number Code"
        },
        {
          "743",
          "Entity’S Credential/Enrollment Information"
        },
        {
          "744",
          "Services/Charges Related To The Treatment Of A Hospital-Acquired Condition Or Preventable Medical Error"
        },
        {
          "745",
          "Identifier Qualifier "
        },
        {
          "746",
          "Duplicate Submission"
        },
        {
          "747",
          "Hospice Employee Indicator"
        },
        {
          "748",
          "Corrected Data Note: Requires A Second Status Code To Identify The Corrected Data"
        },
        {
          "749",
          "Date Of Injury/Illness"
        },
        {
          "750",
          "Auto Accident State Or Province Code"
        },
        {
          "751",
          "Ambulance Pick-Up State Or Province Code"
        },
        {
          "752",
          "Ambulance Drop-Off State Or Province Code"
        },
        {
          "753",
          "Co-Pay Status Code"
        },
        {
          "754",
          "Entity Name Suffix. "
        },
        {
          "755",
          "Entity's Primary Identifier. "
        },
        {
          "756",
          "Entity's Received Date. "
        },
        {
          "757",
          "Last Seen Date"
        },
        {
          "758",
          "Repriced Approved Hcpcs Code"
        },
        {
          "759",
          "Round Trip Purpose Description"
        },
        {
          "760",
          "Tooth Status Code"
        },
        {
          "761",
          "Entity's Referral Number. "
        },
        {
          "762",
          "Locum Tenens Provider Identifier. Code Must Be Used With Entity Code 82 - Rendering Provider"
        },
        {
          "763",
          "Ambulance Pickup Zipcode"
        },
        {
          "764",
          "Professional Charges Are Non Covered"
        },
        {
          "765",
          "Institutional Charges Are Non Covered"
        },
        {
          "766",
          "Services Were Performed During A Health Insurance Exchange (Hix) Premium Payment Grace Period"
        },
        {
          "767",
          "Qualifications For Emergent/Urgent Care"
        },
        {
          "768",
          "Service Date Outside The Accidental Injury Coverage Period"
        },
        {
          "769",
          "Dme Repair Or Maintenance"
        },
        {
          "771",
          "Claim Submitted Prematurely. Please Resubmit After Crossover/Payer To Payer Cob Allotted Waiting Period"
        },
        {
          "772",
          "The greatest level of diagnosis code specificity is required"
        },
        {
          "773",
          "One calendar year per claim"
        },
        {
          "774",
          "Experimental/Investigational"
        },
        {
          "775",
          "Entity Type Qualifier (Person/Non-Person Entity)"
        },
        {
          "776",
          "Pre/Post-operative care"
        },
        {
          "777",
          "Processed based on multiple or concurrent procedure rules"
        },
        {
          "778",
          "Non-Compensable incident/event"
        },
        {
          "779",
          "Service submitted for the same/similar service within a set timeframe"
        },
        {
          "780",
          "Lifetime benefit maximum"
        },
        {
          "781",
          "Claim has been identified as a readmission"
        },
        {
          "782",
          "Second surgical opinion"
        },
        {
          "783",
          "Federal sequestration adjustment"
        }
      };
        }

        public static Dictionary<string, string> ClaimStatusCategory()
        {
            return new Dictionary<string, string>()
      {
        {
          "A0",
          "The claim has been forwarded to another entity"
        },
        {
          "A1",
          "The claim has been received"
        },
        {
          "A2",
          "The claim has been accepted for adjudication"
        },
        {
          "A3",
          "The claim has been rejected and not entered into adjudication"
        },
        {
          "A4",
          "The claim can not be found in adjudication system"
        },
        {
          "A5",
          "The claim has been split upon acceptance into adjudication system"
        },
        {
          "A6",
          "The claim is missing the information specifid and has been rejected"
        },
        {
          "A7",
          "The claim has invalid information and has been rejected"
        },
        {
          "A8",
          "The claim has relational field in error and has been rejected"
        },
        {
          "P0",
          "Pending – A pended claim is one for which no remittance is issued"
        },
        {
          "P1",
          "Pending/In Process – The claim is in adjudication system"
        },
        {
          "P2",
          "Pending/Payer Review – The claim is suspended and is pending review (E.g. Medical Review, Repricing etc.)"
        },
        {
          "P3",
          "Pending/Provider – The claim is waiting for information that has already been requested from Provider"
        },
        {
          "P4",
          "The claim is payer administrator/system hold"
        },
        {
          "P5",
          "The claim is payer administrator/system hold"
        },
        {
          "F0",
          "Finalized – The claim/encounter has completed the adjudication cycle and no more action will be taken"
        },
        {
          "F1",
          "Finalized/Payment – The claim/line has been paid"
        },
        {
          "F2",
          "Finalized/Denial – the claim/line has been denied"
        },
        {
          "F3",
          "Finalized/Revised – Adjudication information has been changed"
        },
        {
          "F3F",
          "Finalized/Forwarded – The claim processing has been completed and forwarded to a subsequent payer as identified in this payer's RECORDS"
        },
        {
          "F3N",
          "Finalized/Not forwarded – The claim processing has been completed. The claim/encounter has not been forwarded to any payer"
        },
        {
          "F4",
          "Finalized/Adjudication complete – No payment forthcoming. The claim has been adjudicated"
        },
        {
          "F5",
          "Finalized/Cannot process the claim"
        },
        {
          "R0",
          "Requests for additional Information/General Requests – Requests that don't fall into other R – type categories"
        },
        {
          "R1",
          "Requests for additional Information/Entity Requests – Requests for information about specific entities (subscribers, patients, various providers)"
        },
        {
          "R3",
          "Requests for additional Information/Claim/Line – Requests for information that could normally be submitted on a claim"
        },
        {
          "R4",
          "Requests for additional Information/Documentation – Requests for additional supporting documentation. Examples: Certification, X–ray, Notes"
        },
        {
          "R5",
          "Request for additional information/more specific detail – Additional information as a follow up to a previous request is needed. The original information was received but is inadequate. More specific/detailed information is requested"
        },
        {
          "R6",
          "Requests for additional information – Regulatory requirements"
        },
        {
          "R7",
          "Requests for additional information – Confirm care is consistent with Health Plan policy coverage"
        },
        {
          "R8",
          "Requests for additional information – Confirm care is consistent with health plan coverage exceptions"
        },
        {
          "R9",
          "Requests for additional information – Determination of medical necessity"
        },
        {
          "R10",
          "Requests for additional information – Support a filed grievance or appeal"
        },
        {
          "R11",
          "Requests for additional information – Pre–payment review of claims"
        },
        {
          "R12",
          "Requests for additional information – Clarification or justification of use for specified procedure code"
        },
        {
          "R13",
          "Requests for additional information – Original documents submitted are not readable. Used only for subsequent request(s)"
        },
        {
          "R14",
          "Requests for additional information – Original documents received are not what was requested. Used only for subsequent request(s)"
        },
        {
          "R15",
          "Requests for additional information – Workers Compensation coverage determination"
        },
        {
          "R16",
          "Requests for additional information – Eligibility determination"
        },
        {
          "R17",
          "Replacement of a Prior Request. Used to indicate that the current attachment request replaces a prior attachment request"
        },
        {
          "E0",
          "Response not possible – error on submitted request data"
        },
        {
          "E1",
          "Response not possible – System Status"
        },
        {
          "E2",
          "Information Holder is not responding; resubmit at a later time"
        },
        {
          "E3",
          "Correction required – relational fields in error"
        },
        {
          "E4",
          "Trading partner agreement specific requirement not met: Data correction required. (Usage: A status code identifying the type of information requested must be sent)"
        },
        {
          "D0",
          "Data Search Unsuccessful – The payer is unable to return status on the requested claim(s) based on the submitted search criteria"
        }
      };
        }

        public static Dictionary<string, string> ClaimStatus_STC01_3()
        {
            return new Dictionary<string, string>()
      {
        {
          "13",
          "Contracted Service Provider"
        },
        {
          "17",
          "Consultant's Office"
        },
        {
          "AY",
          "Clearing House"
        },
        {
          "1E",
          "Health Maintenance Organization (HMO)"
        },
        {
          "1G",
          "Oncology Center"
        },
        {
          "1H",
          "Kidney Dialysis Unit"
        },
        {
          "1I",
          "Preferred Provider Organization (PPO)"
        },
        {
          "1O",
          "Acute Care Hospital"
        },
        {
          "1P",
          "Provider"
        },
        {
          "1Q",
          "Military Facility"
        },
        {
          "1R",
          "University, College or School"
        },
        {
          "1S",
          "Outpatient Surgicenter"
        },
        {
          "1T",
          "Physician, Clinic or Group Practice"
        },
        {
          "1U",
          "Long Term Care Facility"
        },
        {
          "1V",
          "Extended Care Facility"
        },
        {
          "1W",
          "Psychiatric Health Facility"
        },
        {
          "1X",
          "Laboratory"
        },
        {
          "1Y",
          "Retail Pharmacy"
        },
        {
          "1Z",
          "Home Health Care"
        },
        {
          "28",
          "Subcontractor"
        },
        {
          "2A",
          "Federal, State, County or City Facility"
        },
        {
          "2B",
          "Third-Party Administrator"
        },
        {
          "2D",
          "Miscellaneous Health Care Facility"
        },
        {
          "2E",
          "Non-Health Care Miscellaneous Facility"
        },
        {
          "2I",
          "Church Operated Facility"
        },
        {
          "2K",
          "Partnership"
        },
        {
          "2P",
          "Public Health Service Facility"
        },
        {
          "2Q",
          "Veterans Administration Facility"
        },
        {
          "2S",
          "Public Health Service Indian Service Facility"
        },
        {
          "2Z",
          "Hospital Unit of an Institution (prison hospital, college infirmary, etc.)"
        },
        {
          "30",
          "Service Supplier"
        },
        {
          "36",
          "Employer"
        },
        {
          "3A",
          "Hospital Unit Within an Institution for the Mentally Retarded"
        },
        {
          "3C",
          "Tuberculosis and Other Respiratory Diseases Facility"
        },
        {
          "3D",
          "Obstetrics and Gynecology Facility"
        },
        {
          "3E",
          "Eye, Ear, Nose and Throat Facility"
        },
        {
          "3F",
          "Rehabilitation Facility"
        },
        {
          "3G",
          "Orthopedic Facility"
        },
        {
          "3H",
          "Chronic Disease Facility"
        },
        {
          "3I",
          "Other Specialty Facility"
        },
        {
          "3J",
          "Children's General Facility"
        },
        {
          "3K",
          "Children's Hospital Unit of an Institution"
        },
        {
          "3L",
          "Children's Psychiatric Facility"
        },
        {
          "3M",
          "Children's Tuberculosis and Other Respiratory Diseases Facility"
        },
        {
          "3N",
          "Children's Eye, Ear, Nose and Throat Facility"
        },
        {
          "3O",
          "Children's Rehabilitation Facility"
        },
        {
          "3P",
          "Children's Orthopedic Facility"
        },
        {
          "3Q",
          "Children's Chronic Disease Facility"
        },
        {
          "3R",
          "Children's Other Speciality Facility"
        },
        {
          "3S",
          "Institution for Mental Retardation"
        },
        {
          "3T",
          "Alcoholism and Other Chemical Dependency Facility"
        },
        {
          "3U",
          "General Inpatient Care the AIDS/ARC Facility"
        },
        {
          "3V",
          "AIDS/ARC Unit"
        },
        {
          "3W",
          "Specialized Outpatient Program for AIDS/ARC"
        },
        {
          "3X",
          "Alcohol/Drug Abuse or Dependency Inpatient Unit"
        },
        {
          "3Y",
          "Alcohol/Drug Abuse or Dependency Outpatient Services"
        },
        {
          "3Z",
          "Arthritis Treatment Center"
        },
        {
          "40",
          "Receiver"
        },
        {
          "41",
          "Submitter"
        },
        {
          "44",
          "Data Processing Service Bureau"
        },
        {
          "45",
          "Drop-off Location"
        },
        {
          "4A",
          "Birthing Room/LDRP Room"
        },
        {
          "4B",
          "Burn Care Unit"
        },
        {
          "4C",
          "Cardiac Catheterization Laboratory"
        },
        {
          "4D",
          "Open-Heart Surgery Facility"
        },
        {
          "4E",
          "Cardiac Intensive Care Unit"
        },
        {
          "4F",
          "Angioplasty Facility"
        },
        {
          "4G",
          "Chronic Obstructive Pulmonary Disease Service Facility"
        },
        {
          "4H",
          "Emergency Department"
        },
        {
          "4I",
          "Trauma Center (Certified)"
        },
        {
          "4J",
          "Extracorporeal Shock-Wave Lithotripter (ESWL) Unit"
        },
        {
          "4L",
          "Genetic Counseling/Screening Services"
        },
        {
          "4M",
          "Adult Day Care Program Facility"
        },
        {
          "4N",
          "Alzheimer's Diagnostic / Assessment Services"
        },
        {
          "4O",
          "Comprehensive Geriatric Assessment Facility"
        },
        {
          "4P",
          "Emergency Response (Geriatric) Unit"
        },
        {
          "4Q",
          "Geriatric Acute Care Unit"
        },
        {
          "4R",
          "Geriatric Clinics"
        },
        {
          "4S",
          "Respite Care Facility"
        },
        {
          "4U",
          "Patient Education Unit"
        },
        {
          "4V",
          "Community Health Promotion Facility"
        },
        {
          "4W",
          "Worksite Health Promotion Facility"
        },
        {
          "4X",
          "Hemodialysis Facility"
        },
        {
          "4Y",
          "Home Health Services"
        },
        {
          "4Z",
          "Hospice"
        },
        {
          "5B",
          "Histopathology Laboratory"
        },
        {
          "5C",
          "Blood Bank"
        },
        {
          "5D",
          "Neonatal Intensive Care Unit"
        },
        {
          "5E",
          "Obstetrics Unit"
        },
        {
          "5F",
          "Occupational Health Services"
        },
        {
          "5G",
          "Organized Outpatient Services"
        },
        {
          "5H",
          "Pediatric Acute Inpatient Unit"
        },
        {
          "5I",
          "Psychiatric Child/Adolescent Services"
        },
        {
          "5J",
          "Psychiatric Consultation-Liaison Services"
        },
        {
          "5K",
          "Psychiatric Education Services"
        },
        {
          "5L",
          "Psychiatric Emergency Services"
        },
        {
          "5M",
          "Psychiatric Geriatric Services"
        },
        {
          "5N",
          "Psychiatric Inpatient Unit"
        },
        {
          "5O",
          "Psychiatric Outpatient Services"
        },
        {
          "5P",
          "Psychiatric Partial Hospitalization Program"
        },
        {
          "5Q",
          "Megavoltage Radiation Therapy Unit"
        },
        {
          "5R",
          "Radioactive Implants Unit"
        },
        {
          "5S",
          "Therapeutic Radioisotope Facility"
        },
        {
          "5T",
          "X-Ray Radiation Therapy Unit"
        },
        {
          "5U",
          "CT Scanner Unit"
        },
        {
          "5V",
          "Diagnostic Radioisotope Facility"
        },
        {
          "5W",
          "Magnetic Resonance Imaging (MRI) Facility"
        },
        {
          "5X",
          "Ultrasound Unit"
        },
        {
          "5Y",
          "Rehabilitation Inpatient Unit"
        },
        {
          "5Z",
          "Rehabilitation Outpatient Services"
        },
        {
          "61",
          "Performed At"
        },
        {
          "6A",
          "Reproductive Health Services"
        },
        {
          "6B",
          "Skilled Nursing or Other Long-Term Care Unit"
        },
        {
          "6C",
          "Single Photon Emission Computerized Tomography (SPECT) Unit"
        },
        {
          "6D",
          "Organized Social Work Service Facility"
        },
        {
          "6E",
          "Outpatient Social Work Services"
        },
        {
          "6F",
          "Emergency Department Social Work Services"
        },
        {
          "6G",
          "Sports Medicine Clinic/Services"
        },
        {
          "6H",
          "Hospital Auxiliary Unit"
        },
        {
          "6I",
          "Patient Representative Services"
        },
        {
          "6J",
          "Volunteer Services Department"
        },
        {
          "6K",
          "Outpatient Surgery Services"
        },
        {
          "6L",
          "Organ/Tissue Transplantation Unit"
        },
        {
          "6M",
          "Orthopedic Surgery Facility"
        },
        {
          "6N",
          "Occupational Therapy Services"
        },
        {
          "6O",
          "Physical Therapy Services"
        },
        {
          "6P",
          "Recreational Therapy Services"
        },
        {
          "6Q",
          "Respiratory Therapy Services"
        },
        {
          "6R",
          "Speech Therapy Services"
        },
        {
          "6S",
          "Women's Health Center / Services"
        },
        {
          "6U",
          "Cardiac Rehabilitation Program Facility"
        },
        {
          "6V",
          "Non-Invasive Cardiac Assessment Services"
        },
        {
          "6W",
          "Emergency Medical Technician"
        },
        {
          "6X",
          "Disciplinary Contact"
        },
        {
          "6Y",
          "Case Manager"
        },
        {
          "71",
          "Attending Physician"
        },
        {
          "72",
          "Operating Physician"
        },
        {
          "73",
          "Other Physician"
        },
        {
          "74",
          "Corrected Insured"
        },
        {
          "77",
          "Service Location"
        },
        {
          "7C",
          "Place of Occurrence"
        },
        {
          "80",
          "Hospital"
        },
        {
          "82",
          "Rendering Provider"
        },
        {
          "84",
          "Subscriber's Employer"
        },
        {
          "85",
          "Billing Provider"
        },
        {
          "87",
          "Pay-to Provider"
        },
        {
          "95",
          "Research Institute"
        },
        {
          "CK",
          "Pharmacist"
        },
        {
          "CZ",
          "Admitting Surgeon"
        },
        {
          "D2",
          "Commercial Insurer"
        },
        {
          "DD",
          "Assistant Surgeon"
        },
        {
          "DJ",
          "Consulting Physician"
        },
        {
          "DK",
          "Ordering Physician"
        },
        {
          "DN",
          "Referring Provider"
        },
        {
          "DO",
          "Dependent Name"
        },
        {
          "DQ",
          "Supervising Physician"
        },
        {
          "E1",
          "Person or Other Entity Legally Responsible for a Child"
        },
        {
          "E2",
          "Person or Other Entity With Whom a Child Resides"
        },
        {
          "E7",
          "Previous Employer"
        },
        {
          "E9",
          "Participating Laboratory"
        },
        {
          "FA",
          "Facility"
        },
        {
          "FD",
          "Physical Address"
        },
        {
          "FE",
          "Mail Address"
        },
        {
          "G3",
          "Clinic"
        },
        {
          "GB",
          "Other Insured"
        },
        {
          "GD",
          "Guardian"
        },
        {
          "GI",
          "Paramedic"
        },
        {
          "GJ",
          "Paramedical Company"
        },
        {
          "GK",
          "Previous Insured"
        },
        {
          "GM",
          "Spouse Insured"
        },
        {
          "GY",
          "Treatment Facility"
        },
        {
          "HF",
          "Healthcare Professional Shortage Area (HPSA) Facility"
        },
        {
          "HH",
          "Home Health Agency"
        },
        {
          "I3",
          "Independent Physicians Association (IPA)"
        },
        {
          "IJ",
          "Injection Point"
        },
        {
          "IL",
          "Insured or Subscriber"
        },
        {
          "IN",
          "Insurer"
        },
        {
          "LI",
          "Independent Lab"
        },
        {
          "LR",
          "Legal Representative"
        },
        {
          "MR",
          "Medical Insurance Carrier"
        },
        {
          "OB",
          "Ordered By"
        },
        {
          "OD",
          "Doctor of Optometry"
        },
        {
          "OX",
          "Oxygen Therapy Facility"
        },
        {
          "P0",
          "Patient Facility"
        },
        {
          "P2",
          "Primary Insured or Subscriber"
        },
        {
          "P3",
          "Primary Care Provider"
        },
        {
          "P4",
          "Prior Insurance Carrier"
        },
        {
          "P6",
          "Third Party Reviewing Preferred Provider Organization (PPO)"
        },
        {
          "P7",
          "Third Party Repricing Preferred Provider Organization (PPO)"
        },
        {
          "PE",
          "Payee (subrograted payee)"
        },
        {
          "PR",
          "Payer"
        },
        {
          "PT",
          "Party to Receive Test Report"
        },
        {
          "PV",
          "Party performing certification"
        },
        {
          "PW",
          "Pick up Address"
        },
        {
          "QA",
          "Pharmacy"
        },
        {
          "QB",
          "Purchase Service Provider"
        },
        {
          "QC",
          "Patient"
        },
        {
          "QD",
          "Responsible Party"
        },
        {
          "QE",
          "Policyholder"
        },
        {
          "QH",
          "Physician"
        },
        {
          "QK",
          "Managed Care"
        },
        {
          "QL",
          "Chiropractor"
        },
        {
          "QN",
          "Dentist"
        },
        {
          "QO",
          "Doctor of Osteopathy"
        },
        {
          "QS",
          "Podiatrist"
        },
        {
          "QV",
          "Group Practice"
        },
        {
          "QY",
          "Medical Doctor"
        },
        {
          "RC",
          "Receiving Location"
        },
        {
          "RW",
          "Rural Health Clinic"
        },
        {
          "S4",
          "Skilled Nursing Facility"
        },
        {
          "SJ",
          "Service Provider"
        },
        {
          "SU",
          "Supplier/Manufacturer"
        },
        {
          "T4",
          "Transfer Point"
        },
        {
          "TQ",
          "Third Party Reviewing Organization (TPO)"
        },
        {
          "TT",
          "Transfer To"
        },
        {
          "TU",
          "Third Party Repricing Organization (TPO)"
        },
        {
          "UH",
          "Nursing Home"
        },
        {
          "X3",
          "Utilization Management Organization"
        },
        {
          "X4",
          "Spouse"
        },
        {
          "X5",
          "Durable Medical Equipment Supplier"
        },
        {
          "ZZ",
          "Mutually Defined"
        }
      };
        }

        public static Dictionary<string, string> StatusCodes999_IK502()
        {
            return new Dictionary<string, string>()
      {
        {
          "1",
          "The transaction set not supported"
        },{
          "2",
          "Transaction set trailer missing"
        },{
          "3",
          "The transaction set control number in header and trailer do not match"
        },{
          "4",
          "Number of included segments does not match actual count"
        },{
          "5",
          "One or more segments in error"
        },{
          "6",
          "Missing or invalid transaction set identifier"
        },{
          "7",
          "Missing or invalid transaction set control number (a duplicate transaction number may have occurred)"
        },{
          "18",
          "= Transaction set not in functional group"
        },{
          "19",
          "Invalid transaction set implementation convention reference"
        },{
          "I5",
          "Implementation One or More Segments in Error"
        },{
          "I6",
          "Implementation convention not supported"
        }
            };
        }

        public static Dictionary<string, string> EDI_ERROR_Codes()
        {
            return new Dictionary<string, string>()
            {
                {"E001","Missing/Invalid submitter identifier"},
{"E002","Missing/Invalid receiver identifier"},
{"E003","Missing/Invalid member identifier"},
{"E004","Missing/Invalid subscriber identifier"},
{"E005","Missing/Invalid patient identifier"},
{"E006","Missing/Invalid plan sponsor identifier"},
{"E007","Missing/invalid payee identifier"},
{"E008","Missing/Invalid TPA/broker identifier"},
{"E009","Missing/Invalid premium receiver identifier"},
{"E010","Missing/Invalid premium payer identifier"},
{"E011","Missing/Invalid payer identifier"},
{"E012","Missing/Invalid billing provider identifier"},
{"E013","Missing/Invalid pay to provider identifier"},
{"E014","Missing/Invalid rendering provider identifier"},
{"E015","Missing/Invalid supervising provider identifier"},
{"E016","Missing/Invalid attending provider identifier"},
{"E017","Missing/Invalid other provider identifier"},
{"E018","Missing/Invalid operating provider identifier"},
{"E019","Missing/Invalid referring provider identifier"},
{"E020","Missing/Invalid purchased service provider identifier"},
{"E021","Missing/Invalid service facility identifier"},
{"E022","Missing/Invalid ordering provider identifier"},
{"E023","Missing/Invalid assistant surgeon identifier"},
{"E024","Amount/Quantity out of balance"},
{"E025","Duplicate"},
{"E026","Billing date predates service date"},
{"E027","Business application currently not available"},
{"E028","Sender not authorized for this transaction"},
{"E029","Number of errors exceeds permitted threshold"},
{"E030","Required loop missing"},
{"E031","Required segment missing"},
{"E032","Required element missing"},
{"E033","Situational required loop is missing"},
{"E034","Situational required segment is missing"},
{"E035","Situational required element is missing"},
{"E036","Data too long"},
{"E037","Data too short"},
{"E038","Invalid external code value"},
{"E039","Data value out of sequence"},
{"E040","Not Used data element present"},
{"E041","Too many sub-elements in composite"},
{"E042","Unexpected segment"},
{"E043","Missing data"},
{"E044","Out of range"},
{"E045","Invalid date"},
{"E046","Not matching"},
{"E047","Invalid combination"},
{"E048","Customer identification number does not exist"},
{"E049","Duplicate batch"},
{"E050","Incorrect data"},
{"E051","Incorrect date"},
{"E052","Duplicate transmission"},
{"E053","Invalid claim amount"},
{"E054","Invalid identification code"},
{"E055","Missing or invalid issuer identification"},
{"E056","Missing or invalid item quantity"},
{"E057","Missing or invalid item identification"},
{"E058","Missing or unauthorized transaction type code"},
{"E059","Unknown claim number"},
{"E060","Bin segment contentes not in MIME format"},
{"E061","Missing/invalid MIME header"},
{"E062","Missing/Invalid MIME boundary"},
{"E063","Missing/Invalid MIME transfer encoding"},
{"E064","Missing/Invalid MIME content type"},
{"E065","Missing/Invalid MIME content disposition (filename)"},
{"E066","Missing/Invalid file name extension"},
{"E067","Invalid MIME base64 encoding"},
{"E068","Invalid MIME quoted-printable encoding"},
{"E069","Missing/Invalid MIME line terminator (should be CR+LF)"},
{"E070","Missing/Invalid end of MIME headers"},
{"E071","Missing/Invalid CDA in first MIME body parts"},
{"E072","Missing/Invalid XML tag"},
{"E073","Unrecoverable XML error"},
{"E074","Invalid Data format for HL7 data type"},
{"E075","Missing/Invalid required LOINC answer part(s) in the CDA"},
{"E076","Missing/Invalid Provider information in the CDA"},
{"E077","Missing/Invalid Patient information in the CDA"},
{"E078","Missing/Invalid Attachment Control information in the CDA"},
{"E079","Missing/Invalid LOINC"},
{"E080","Missing/Invalid LOINC Modifier"},
{"E081","Missing/Invalid LOINC code for this attachment type"},
{"E082","Missing/Invalid LOINC Modifier for this attachment type"},
{"E083","Situational prohibited element is present"},
{"E084","Duplicate qualifier value in repeated segment within a single loop"},
{"E085","Situational required composite element is missing"},
{"E086","Situational required repeating element is missing"},
{"E087","Situational prohibited loop is present"},
{"E088","Situational prohibited segment is present"},
{"E089","Situational prohibited composite element is present"},
{"E090","Situational prohibited repeating element is present"},
{"E091","Transaction successfully received but not processed as applicable business function not performed."},
{"E092","Missing/Invalid required SNOMED CT answer part(s) in the CDA"},
{"E093","Matching Policy Information/Document not found."},
{"E094","Financial Assistance not permitted across multiple marketplaces - Double Dip Check Edit Identified."},
{"E095","Business Process transaction out of sequence."},
{"E096","Advanced Premium Tax Credit is more than Total Premium."},
{"E097","Marketplace, Off Market Variant."},
{"E098","Maintenance Type Code"},
{"E099","Maintenance Reason Code"},
{"E100","Additional Maintenance Reason Code"},
{"E101","Enrollment Group member(s) count on transaction does not match Enrollment Group member(s) count found on file of record"},
{"E102","Effective Start Date"},
{"E103","Advanced Payment for Tax Credit (APTC)"},
{"E104","Total Individual Responsibility Amount"},
{"E105","Other Payment Amount 1"},
{"E106","Other Payment Amount 2"},
{"E107","Total Premium Amount"},
{"E108","Individual Premium Amount"},
{"E109","Total Employer Responsibility Amount"},
{"E110","Financial Date Precedes Premium Date"},
{"E111","Exceeds Unique Start Date(s)"},
{"E112","Exceeds Allowable Changes"},
{"E113","Cost Sharing Reduction (CSR) Date precedes the Total Premium Amount Effective Start Date"},
{"E114","Renewal Transaction cannot be processed as it is outside of allocated time period"},
{"E115","Financial Amounts Unchanged by newly reported data"},
{"E116","Effective Start Date does not align with Previous Effective End Date"},
{"E117","Duplicate Payment of Advanced Premium Tax Credit"},
{"E118","Duplicate Payment of Cost Sharing Reduction"},
{"E119","Duplicate Payment of User Fee"},
{"E120","Missing Payment of Advanced Premium Tax Credit"},
{"E121","Missing Payment of Cost Sharing Reduction"},
{"E122","Missing Payment of User Fee"},
{"E123","Advanced Premium Tax Credit (APTC) Payment Mismatch - The Federally Facilitated Marketplace (FFM) or State Based Marketplace (SBM) APTC amount and the Health Plan APTC amount are equal but do not match the APTC payment amount received"},
{"E124","Cost Shared Reduction (CSR) Payment Mismatch - The Federally Facilitated Marketplace (FFM) or State Based Marketplace (SBM) CSR amount and the Health Plan CSR amount are equal but do not match the CSR payment amount received"},
{"E125","User Fee Payment Mismatch - The calculated Federally Facilitated Marketplace (FFM) User Fee amount and the calculated Health Plan User Fee amount are equal but do not match the User Fee payment amount received"},
{"E126","Effectuation Transaction cannot be processed as it is outside of allocated time period"},
{"E127","Cancel Transaction cannot be processed as it is outside of allocated time period"},
{"E128","Termination Transaction cannot be processed as it is outside of allocated time period"},
{"E129","Maintenance Transaction cannot be processed as it is outside of allocated time period"},
{"E130","Policy level cancel/terminations shall not contain health coverage information"},
{"E131","Dependent/Member not included in current coverage"},
{"E132","The data in the transaction does not match the exchange/marketplace type"},
{"E133","Policy Cancelled - cannot be processed"},
{"E134","Policy Non-Effectuated - cannot be processed"},
{"E135","Policy ID"},
{"E136","Subscriber ID"},
{"E137","Member ID"},
{"E138","No Longer Eligible (NLE)"},
{"E139","Exchange Assigned"},
{"E140","Issuer Assigned"},
{"E141","Issuer Prior Assigned"},
{"E142","Action results already match current information on file"},
{"E143","Action results do not match current information on file"},
{"E144","Cancellation Transaction"},
{"E145","Initial Enrollment Transaction"},
{"E146","Maintenance Transaction"},
{"E147","Reinstatement Transaction"},
{"E148","Termination Transaction"},
{"E149","Email Address"},
{"E150","Mailing Address"},
{"E151","Telephone Number"},
{"E152","Consumer executed voluntary withdrawal of coverage"},
{"E153","Unable to be processed causing a gap or overlap in coverage dates"},
{"E154","Invoke the Enrollment Resolution and Reconciliation (ER&R) manual process"},
{"E155","Marketplace Coverage in Effect"},
{"E156","Reinstatement transaction cannot be processed as it is outside of the allocated time period"},
{"E157","Coverage Start Date"},
{"E158","Coverage End Date"},
{"E159","Dependent/Member shall not be included in Policy Level"},
{"E160","One day coverage"},
{"E161","Invalid"},
{"E162","Eligibility Begin Date"},
{"E163","Associated submission not found"},
{"E164","Exceeds Receiver Allowed Occurrences"},
{"E165","HL7 US Realm Header Legal Authenticator data is missing"},
{"E166","HL7 US Realm Header Author data is missing"},
{"E167","HL7 US Realm Header SetID data is missing"},
{"E168","HL7 US Realm Header VersionNumber data is missing"},
{"E169","HL7 C-CDA Structured document sections name data is missing"},
{"E170","HL7 C-CDA Structured document sections title data is missing"},
{"E171","HL7 C-CDA Structured document narrative block (text) data is missing"},
{"E172","HL7 C-CDA Unstructured document LOINC Code is missing"},
{"E173","HL7 C-CDA Unstructured document contained a reference to a URL or URI"},
{"E174","HL7 C-CDA Unstructured document @mediaType (MIME type) is missing"},
{"E175","HL7 C-CDA Unstructured document included more than 1 @mediaType (MIME type)"},
{"E176","HL7 C-CDA Unstructured document Base64 encoding does not meet the RFC 4648 requirements"},
{"E177","HL7 C-CDA Unstructured document compression does not meet the RFC 1951 requirements"},
{"E178","HL7 C-CDA LOINC code does not match the LOINC code in the request"},
{"E179","HL7 Attachment Control Number is missing"},
{"E180","Missing Billing provider affiliation for the Rendering provider(s)."},
{"E181","Invalid affiliation between Rendering and Billing providers."},
{"E182","System Delay-No Additional Action Required"},
{"E183","System Delay-Resubmission Required"},
{"W001","Missing/Invalid submitter identifier"},
{"W002","Missing/Invalid receiver identifier"},
{"W003","Missing/Invalid member identifier"},
{"W004","Missing/Invalid subscriber identifier"},
{"W005","Missing/Invalid patient identifier"},
{"W006","Missing/Invalid plan sponsor identifier"},
{"W007","Missing/invalid payee identifier"},
{"W008","Missing/Invalid TPA/broker identifier"},
{"W009","Missing/Invalid premium receiver identifier"},
{"W010","Missing/Invalid premium payer identifier"},
{"W011","Missing/Invalid payer identifier"},
{"W012","Missing/Invalid billing provider identifier"},
{"W013","Missing/Invalid pay to provider identifier"},
{"W014","Missing/Invalid rendering provider identifier"},
{"W015","Missing/Invalid supervising provider identifier"},
{"W016","Missing/Invalid attending provider identifier"},
{"W017","Missing/Invalid other provider identifier"},
{"W018","Missing/Invalid operating provider identifier"},
{"W019","Missing/Invalid referring provider identifier"},
{"W020","Missing/Invalid purchased service provider identifier"},
{"W021","Missing/Invalid service facility identifier"},
{"W022","Missing/Invalid ordering provider identifier"},
{"W023","Missing/Invalid assistant surgeon identifier"},
{"W024","Amount/Quantity out of balance"},
{"W025","Duplicate"},
{"W026","Billing date predates service date"},
{"W027","Business application currently not available"},
{"W028","Sender not authorized for this transaction"},
{"W029","Number of errors exceeds permitted threshold"},
{"W030","Required loop missing"},
{"W031","Required segment missing"},
{"W032","Required element missing"},
{"W033","Situational required loop is missing"},
{"W034","Situational required segment is missing"},
{"W035","Situational required element is missing"},
{"W036","Data too long"},
{"W037","Data too short"},
{"W038","Invalid external code value"},
{"W039","Data value out of sequence"},
{"W040","Not Used data element present"},
{"W041","Too many sub-elements in composite"},
{"W042","Unexpected segment"},
{"W043","Missing data"},
{"W044","Out of range"},
{"W045","Invalid date"},
{"W046","Not matching"},
{"W047","Invalid combination"},
{"W048","Customer identification number does not exist"},
{"W049","Duplicate batch"},
{"W050","Incorrect data"},
{"W051","Incorrect date"},
{"W052","Duplicate transmission"},
{"W053","Invalid claim amount"},
{"W054","Invalid identification code"},
{"W055","Missing or invalid issuer identification"},
{"W056","Missing or invalid item quantity"},
{"W057","Missing or invalid item identification"},
{"W058","Missing or unauthorized transaction type code"},
{"W059","Unknown claim number"},
{"W060","Bin segment contents not in MIME format"},
{"W061","Missing/Invalid MIME header"},
{"W062","Missing/Invalid MIME boundary"},
{"W063","Missing/Invalid MIME transfer encoding"},
{"W064","Missing/Invalid MIME content type"},
{"W065","Missing/Invalid MIME content disposition (filename)"},
{"W066","Missing/Invalid file name extension"},
{"W067","Invalid MIME base64 encoding"},
{"W068","Invalid MIME quoted-printable encoding"},
{"W069","Missing/Invalid MIME line terminator (should be CR+LF)"},
{"W070","Missing/Invalid end of MIME headers"},
{"W071","Missing/Invalid CDA in first MIME body parts"},
{"W072","Missing/Invalid XML tag"},
{"W073","Unrecoverable XML error"},
{"W074","Invalid Data format for HL7 data type"},
{"W075","Missing/Invalid required LOINC answer part(s) in the CDA"},
{"W076","Missing/Invalid Provider information in the CDA"},
{"W077","Missing/Invalid Patient information in the CDA"},
{"W078","Missing/Invalid Attachment Control information in the CDA"},
{"W079","Missing/Invalid LOINC"},
{"W080","Missing/Invalid LOINC Modifier"},
{"W081","Missing/Invalid LOINC code for this attachment type"},
{"W082","Missing/Invalid LOINC Modifier for this attachment type"},
{"W083","Situational prohibited element is present"},
{"W084","Duplicate qualifier value in repeated segment within a single loop"},
{"W085","Situational required composite element is missing"},
{"W086","Situational required repeating element is missing"},
{"W087","Situational prohibited loop is present"},
{"W088","Situational prohibited segment is present"},
{"W089","Situational prohibited composite element is present"},
{"W090","Situational prohibited repeating element is present"},
{"W091","Transaction successfully received but not processed as applicable business function not performed."},
{"W092","Missing/Invalid required SNOMED CT answer part(s) in the CDA"},
{"W093","Matching Policy Information/Document not found."},
{"W094","Financial Assistance not permitted across multiple marketplaces - Double Dip Check Edit Identified."},
{"W095","Business Process transaction out of sequence."},
{"W096","Advanced Premium Tax Credit is more than Total Premium."},
{"W097","Marketplace, Off Market Variant."},
{"W098","Maintenance Type Code"},
{"W099","Maintenance Reason Code"},
{"W100","Additional Maintenance Reason Code"},
{"W101","Enrollment Group member(s) count on transaction does not match Enrollment Group member(s) count found on file of record"},
{"W102","Effective Start Date"},
{"W103","Advanced Payment for Tax Credit (APTC)"},
{"W104","Total Individual Responsibility Amount"},
{"W105","Other Payment Amount 1"},
{"W106","Other Payment Amount 2"},
{"W107","Total Premium Amount"},
{"W108","Individual Premium Amount"},
{"W109","Total Employer Responsibility Amount"},
{"W110","Financial Date Precedes Premium Date"},
{"W111","Exceeds Unique Start Date(s)"},
{"W112","Exceeds Allowable Changes"},
{"W113","Cost Sharing Reduction (CSR) Date precedes the Total Premium Amount Effective Start Date"},
{"W114","Renewal Transaction cannot be processed as it is outside of allocated time period"},
{"W115","Financial Amounts Unchanged by newly reported data"},
{"W116","Effective Start Date does not align with Previous Effective End Date"},
{"W117","Duplicate Payment of Advanced Premium Tax Credit"},
{"W118","Duplicate Payment of Cost Sharing Reduction"},
{"W119","Duplicate Payment of User Fee"},
{"W120","Missing Payment of Advanced Premium Tax Credit"},
{"W121","Missing Payment of Cost Sharing Reduction"},
{"W122","Missing Payment of User Fee"},
{"W123","Advanced Premium Tax Credit (APTC) Payment Mismatch - The Federally Facilitated Marketplace (FFM) or State Based Marketplace (SBM) APTC amount and the Health Plan APTC amount are equal but do not match the APTC payment amount received"},
{"W124","Cost Shared Reduction (CSR) Payment Mismatch - The Federally Facilitated Marketplace (FFM) or State Based Marketplace (SBM) CSR amount and the Health Plan CSR amount are equal but do not match the CSR payment amount received"},
{"W125","User Fee Payment Mismatch - The calculated Federally Facilitated Marketplace (FFM) User Fee amount and the calculated Health Plan User Fee amount are equal but do not match the User Fee payment amount received"},
{"W126","Effectuation Transaction cannot be processed as it is outside of allocated time period"},
{"W127","Cancel Transaction cannot be processed as it is outside of allocated time period"},
{"W128","Termination Transaction cannot be processed as it is outside of allocated time period"},
{"W129","Maintenance Transaction cannot be processed as it is outside of allocated time period"},
{"W130","Policy level cancel/terminations shall not contain health coverage information"},
{"W131","Dependent/Member not included in current coverage"},
{"W132","The data in the transaction does not match the exchange/marketplace type"},
{"W133","Policy Cancelled - cannot be processed"},
{"W134","Policy Non-Effectuated - cannot be processed"},
{"W135","Policy ID"},
{"W136","Subscriber ID"},
{"W137","Member ID"},
{"W138","No Longer Eligible (NLE)"},
{"W139","Exchange Assigned"},
{"W140","Issuer Assigned"},
{"W141","Issuer Prior Assigned"},
{"W142","Action results already match current information on file"},
{"W143","Action results do not match current information on file"},
{"W144","Cancellation Transaction"},
{"W145","Initial Enrollment Transaction"},
{"W146","Maintenance Transaction"},
{"W147","Reinstatement Transaction"},
{"W148","Termination Transaction"},
{"W149","Email Address"},
{"W150","Mailing Address"},
{"W151","Telephone Number"},
{"W152","Consumer executed voluntary withdrawal of coverage"},
{"W153","Unable to be processed causing a gap or overlap in coverage dates"},
{"W154","Invoke the Enrollment Resolution and Reconciliation (ER&R) manual process"},
{"W155","Marketplace Coverage in Effect"},
{"W156","Reinstatement transaction cannot be processed as it is outside of the allocated time period"},
{"W157","Coverage Start Date"},
{"W158","Coverage End Date"},
{"W159","Dependent/Member shall not be included in Policy Level"},
{"W160","One day coverage"},
{"W161","Invalid"},
{"W162","Eligibility Begin Date"},
{"W163","Associated submission not found"},
{"W164","Exceeds Receiver Allowed Occurrences"},
{"W165","HL7 US Realm Header Legal Authenticator data is missing"},
{"W166","HL7 US Realm Header Author data is missing"},
{"W167","HL7 US Realm Header SetID data is missing"},
{"W168","HL7 US Realm Header VersionNumber data is missing"},
{"W169","HL7 C-CDA Structured document sections name data is missing"},
{"W170","HL7 C-CDA Structured document sections title data is missing"},
{"W171","HL7 C-CDA Structured document narrative block (text) data is missing"},
{"W172","HL7 C-CDA Unstructured document LOINC Code is missing"},
{"W173","HL7 C-CDA Unstructured document contained a reference to a URL or URI"},
{"W174","HL7 C-CDA Unstructured document @mediaType (MIME type) is missing"},
{"W175","HL7 C-CDA Unstructured document included more than 1 @mediaType (MIME type)"},
{"W176","HL7 C-CDA Unstructured document Base64 encoding does not meet the RFC 4648 requirements"},
{"W177","HL7 C-CDA Unstructured document compression does not meet the RFC 1951 requirements"},
{"W178","HL7 C-CDA LOINC code does not match the LOINC code in the request"},
{"W179","HL7 Attachment Control Number is missing"},
{"W180","Missing Billing provider affiliation for the Rendering provider(s)."},
{"W181","Invalid affiliation between Rendering and Billing providers."},
{"W182","System Delay-No Additional Action Required"},
{"W183","System Delay-Resubmission Required"}

            };
        }

    }
}
