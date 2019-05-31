#pragma warning disable
namespace mTaka.Utility.ISO20022.Pacs008
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Collections.Generic;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IsNullable = true, ElementName = "Document")]
    public class Document
    {

        #region Private fields
        private FIToFICustomerCreditTransferV07 _fIToFICstmrCdtTrf;

        private static XmlSerializer serializer;
        #endregion

        public FIToFICustomerCreditTransferV07 FIToFICstmrCdtTrf
        {
            get
            {
                return this._fIToFICstmrCdtTrf;
            }
            set
            {
                this._fIToFICstmrCdtTrf = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(Document));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether FIToFICstmrCdtTrf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeFIToFICstmrCdtTrf()
        {
            return (_fIToFICstmrCdtTrf != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current Document object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an Document object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output Document object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out Document obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Document);
            input = XmlSerializerHelper.FilteredXml(input);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out Document obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static Document Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((Document)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static Document Deserialize(System.IO.Stream s)
        {
            return ((Document)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current Document object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an Document object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Document object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Document obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Document);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Document obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Document LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class FIToFICustomerCreditTransferV07
    {

        #region Private fields
        private GroupHeader70 _grpHdr;

        private List<CreditTransferTransaction30> _cdtTrfTxInf;

        private List<SupplementaryData1> _splmtryData;

        private static XmlSerializer serializer;
        #endregion

        public GroupHeader70 GrpHdr
        {
            get
            {
                return this._grpHdr;
            }
            set
            {
                this._grpHdr = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("CdtTrfTxInf")]
        public List<CreditTransferTransaction30> CdtTrfTxInf
        {
            get
            {
                return this._cdtTrfTxInf;
            }
            set
            {
                this._cdtTrfTxInf = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("SplmtryData")]
        public List<SupplementaryData1> SplmtryData
        {
            get
            {
                return this._splmtryData;
            }
            set
            {
                this._splmtryData = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(FIToFICustomerCreditTransferV07));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether CdtTrfTxInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtTrfTxInf()
        {
            return CdtTrfTxInf != null && CdtTrfTxInf.Count > 0;
        }

        /// <summary>
        /// Test whether SplmtryData should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSplmtryData()
        {
            return SplmtryData != null && SplmtryData.Count > 0;
        }

        /// <summary>
        /// Test whether GrpHdr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeGrpHdr()
        {
            return (_grpHdr != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current FIToFICustomerCreditTransferV07 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an FIToFICustomerCreditTransferV07 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output FIToFICustomerCreditTransferV07 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out FIToFICustomerCreditTransferV07 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(FIToFICustomerCreditTransferV07);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out FIToFICustomerCreditTransferV07 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static FIToFICustomerCreditTransferV07 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((FIToFICustomerCreditTransferV07)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static FIToFICustomerCreditTransferV07 Deserialize(System.IO.Stream s)
        {
            return ((FIToFICustomerCreditTransferV07)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current FIToFICustomerCreditTransferV07 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an FIToFICustomerCreditTransferV07 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output FIToFICustomerCreditTransferV07 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out FIToFICustomerCreditTransferV07 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(FIToFICustomerCreditTransferV07);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out FIToFICustomerCreditTransferV07 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static FIToFICustomerCreditTransferV07 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class GroupHeader70
    {

        #region Private fields
        private bool _shouldSerializeIntrBkSttlmDt;

        private bool _shouldSerializeCtrlSum;

        private bool _shouldSerializeBtchBookg;

        private bool _shouldSerializeCreDtTm;

        private string _msgId;

        private System.DateTime _creDtTm;

        private bool _btchBookg;

        private string _nbOfTxs;

        private decimal _ctrlSum;

        private ActiveCurrencyAndAmount _ttlIntrBkSttlmAmt;

        private System.DateTime _intrBkSttlmDt;

        private SettlementInstruction4 _sttlmInf;

        private PaymentTypeInformation21 _pmtTpInf;

        private BranchAndFinancialInstitutionIdentification5 _instgAgt;

        private BranchAndFinancialInstitutionIdentification5 _instdAgt;

        private static XmlSerializer serializer;
        #endregion

        public string MsgId
        {
            get
            {
                return this._msgId;
            }
            set
            {
                this._msgId = value;
            }
        }

        public System.DateTime CreDtTm
        {
            get
            {
                return this._creDtTm;
            }
            set
            {
                this._creDtTm = value;
                _shouldSerializeCreDtTm = true;
            }
        }

        public bool BtchBookg
        {
            get
            {
                return this._btchBookg;
            }
            set
            {
                this._btchBookg = value;
                _shouldSerializeBtchBookg = true;
            }
        }

        public string NbOfTxs
        {
            get
            {
                return this._nbOfTxs;
            }
            set
            {
                this._nbOfTxs = value;
            }
        }

        public decimal CtrlSum
        {
            get
            {
                return this._ctrlSum;
            }
            set
            {
                this._ctrlSum = value;
                _shouldSerializeCtrlSum = true;
            }
        }

        public ActiveCurrencyAndAmount TtlIntrBkSttlmAmt
        {
            get
            {
                return this._ttlIntrBkSttlmAmt;
            }
            set
            {
                this._ttlIntrBkSttlmAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime IntrBkSttlmDt
        {
            get
            {
                return this._intrBkSttlmDt;
            }
            set
            {
                this._intrBkSttlmDt = value;
                _shouldSerializeIntrBkSttlmDt = true;
            }
        }

        public SettlementInstruction4 SttlmInf
        {
            get
            {
                return this._sttlmInf;
            }
            set
            {
                this._sttlmInf = value;
            }
        }

        public PaymentTypeInformation21 PmtTpInf
        {
            get
            {
                return this._pmtTpInf;
            }
            set
            {
                this._pmtTpInf = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 InstgAgt
        {
            get
            {
                return this._instgAgt;
            }
            set
            {
                this._instgAgt = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 InstdAgt
        {
            get
            {
                return this._instdAgt;
            }
            set
            {
                this._instdAgt = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(GroupHeader70));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether CreDtTm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCreDtTm()
        {
            if (_shouldSerializeCreDtTm)
            {
                return true;
            }
            return (_creDtTm != default(System.DateTime));
        }

        /// <summary>
        /// Test whether BtchBookg should be serialized
        /// </summary>
        public virtual bool ShouldSerializeBtchBookg()
        {
            if (_shouldSerializeBtchBookg)
            {
                return true;
            }
            return (_btchBookg != default(bool));
        }

        /// <summary>
        /// Test whether CtrlSum should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtrlSum()
        {
            if (_shouldSerializeCtrlSum)
            {
                return true;
            }
            return (_ctrlSum != default(decimal));
        }

        /// <summary>
        /// Test whether IntrBkSttlmDt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIntrBkSttlmDt()
        {
            if (_shouldSerializeIntrBkSttlmDt)
            {
                return true;
            }
            return (_intrBkSttlmDt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether TtlIntrBkSttlmAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTtlIntrBkSttlmAmt()
        {
            return (_ttlIntrBkSttlmAmt != null);
        }

        /// <summary>
        /// Test whether SttlmInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSttlmInf()
        {
            return (_sttlmInf != null);
        }

        /// <summary>
        /// Test whether PmtTpInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializePmtTpInf()
        {
            return (_pmtTpInf != null);
        }

        /// <summary>
        /// Test whether InstgAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstgAgt()
        {
            return (_instgAgt != null);
        }

        /// <summary>
        /// Test whether InstdAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstdAgt()
        {
            return (_instdAgt != null);
        }

        /// <summary>
        /// Test whether MsgId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeMsgId()
        {
            return !string.IsNullOrEmpty(MsgId);
        }

        /// <summary>
        /// Test whether NbOfTxs should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNbOfTxs()
        {
            return !string.IsNullOrEmpty(NbOfTxs);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current GroupHeader70 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an GroupHeader70 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output GroupHeader70 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out GroupHeader70 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GroupHeader70);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out GroupHeader70 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static GroupHeader70 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((GroupHeader70)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static GroupHeader70 Deserialize(System.IO.Stream s)
        {
            return ((GroupHeader70)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current GroupHeader70 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an GroupHeader70 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output GroupHeader70 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out GroupHeader70 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GroupHeader70);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out GroupHeader70 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static GroupHeader70 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class ActiveCurrencyAndAmount
    {

        #region Private fields
        private bool _shouldSerializeValue;

        private string _ccy;

        private decimal _value;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Ccy
        {
            get
            {
                return this._ccy;
            }
            set
            {
                this._ccy = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
                _shouldSerializeValue = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(ActiveCurrencyAndAmount));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Value should be serialized
        /// </summary>
        public virtual bool ShouldSerializeValue()
        {
            if (_shouldSerializeValue)
            {
                return true;
            }
            return (_value != default(decimal));
        }

        /// <summary>
        /// Test whether Ccy should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCcy()
        {
            return !string.IsNullOrEmpty(Ccy);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current ActiveCurrencyAndAmount object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an ActiveCurrencyAndAmount object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ActiveCurrencyAndAmount object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ActiveCurrencyAndAmount obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ActiveCurrencyAndAmount);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ActiveCurrencyAndAmount obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ActiveCurrencyAndAmount Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((ActiveCurrencyAndAmount)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ActiveCurrencyAndAmount Deserialize(System.IO.Stream s)
        {
            return ((ActiveCurrencyAndAmount)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ActiveCurrencyAndAmount object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ActiveCurrencyAndAmount object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ActiveCurrencyAndAmount object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ActiveCurrencyAndAmount obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ActiveCurrencyAndAmount);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ActiveCurrencyAndAmount obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ActiveCurrencyAndAmount LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class SupplementaryData1
    {

        #region Private fields
        private bool _shouldSerializeEnvlp;

        private string _plcAndNm;

        private System.Xml.XmlElement _envlp;

        private static XmlSerializer serializer;
        #endregion

        public string PlcAndNm
        {
            get
            {
                return this._plcAndNm;
            }
            set
            {
                this._plcAndNm = value;
            }
        }

        public System.Xml.XmlElement Envlp
        {
            get
            {
                return this._envlp;
            }
            set
            {
                this._envlp = value;
                _shouldSerializeEnvlp = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(SupplementaryData1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Envlp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeEnvlp()
        {
            if (_shouldSerializeEnvlp)
            {
                return true;
            }
            return (_envlp != default(System.Xml.XmlElement));
        }

        /// <summary>
        /// Test whether PlcAndNm should be serialized
        /// </summary>
        public virtual bool ShouldSerializePlcAndNm()
        {
            return !string.IsNullOrEmpty(PlcAndNm);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current SupplementaryData1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an SupplementaryData1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output SupplementaryData1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out SupplementaryData1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(SupplementaryData1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out SupplementaryData1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static SupplementaryData1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((SupplementaryData1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static SupplementaryData1 Deserialize(System.IO.Stream s)
        {
            return ((SupplementaryData1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current SupplementaryData1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an SupplementaryData1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output SupplementaryData1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out SupplementaryData1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(SupplementaryData1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out SupplementaryData1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static SupplementaryData1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class GarnishmentType1Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType14 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType14 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(GarnishmentType1Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType14));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current GarnishmentType1Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an GarnishmentType1Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output GarnishmentType1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out GarnishmentType1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GarnishmentType1Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out GarnishmentType1Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static GarnishmentType1Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((GarnishmentType1Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static GarnishmentType1Choice Deserialize(System.IO.Stream s)
        {
            return ((GarnishmentType1Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current GarnishmentType1Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an GarnishmentType1Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output GarnishmentType1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out GarnishmentType1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GarnishmentType1Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out GarnishmentType1Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static GarnishmentType1Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType14
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class GarnishmentType1
    {

        #region Private fields
        private GarnishmentType1Choice _cdOrPrtry;

        private string _issr;

        private static XmlSerializer serializer;
        #endregion

        public GarnishmentType1Choice CdOrPrtry
        {
            get
            {
                return this._cdOrPrtry;
            }
            set
            {
                this._cdOrPrtry = value;
            }
        }

        public string Issr
        {
            get
            {
                return this._issr;
            }
            set
            {
                this._issr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(GarnishmentType1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether CdOrPrtry should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdOrPrtry()
        {
            return (_cdOrPrtry != null);
        }

        /// <summary>
        /// Test whether Issr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIssr()
        {
            return !string.IsNullOrEmpty(Issr);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current GarnishmentType1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an GarnishmentType1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output GarnishmentType1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out GarnishmentType1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GarnishmentType1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out GarnishmentType1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static GarnishmentType1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((GarnishmentType1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static GarnishmentType1 Deserialize(System.IO.Stream s)
        {
            return ((GarnishmentType1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current GarnishmentType1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an GarnishmentType1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output GarnishmentType1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out GarnishmentType1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GarnishmentType1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out GarnishmentType1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static GarnishmentType1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class Garnishment2
    {

        #region Private fields
        private bool _shouldSerializeMplyeeTermntnInd;

        private bool _shouldSerializeFmlyMdclInsrncInd;

        private bool _shouldSerializeDt;

        private GarnishmentType1 _tp;

        private PartyIdentification125 _grnshee;

        private PartyIdentification125 _grnshmtAdmstr;

        private string _refNb;

        private System.DateTime _dt;

        private ActiveOrHistoricCurrencyAndAmount _rmtdAmt;

        private bool _fmlyMdclInsrncInd;

        private bool _mplyeeTermntnInd;

        private static XmlSerializer serializer;
        #endregion

        public GarnishmentType1 Tp
        {
            get
            {
                return this._tp;
            }
            set
            {
                this._tp = value;
            }
        }

        public PartyIdentification125 Grnshee
        {
            get
            {
                return this._grnshee;
            }
            set
            {
                this._grnshee = value;
            }
        }

        public PartyIdentification125 GrnshmtAdmstr
        {
            get
            {
                return this._grnshmtAdmstr;
            }
            set
            {
                this._grnshmtAdmstr = value;
            }
        }

        public string RefNb
        {
            get
            {
                return this._refNb;
            }
            set
            {
                this._refNb = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime Dt
        {
            get
            {
                return this._dt;
            }
            set
            {
                this._dt = value;
                _shouldSerializeDt = true;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount RmtdAmt
        {
            get
            {
                return this._rmtdAmt;
            }
            set
            {
                this._rmtdAmt = value;
            }
        }

        public bool FmlyMdclInsrncInd
        {
            get
            {
                return this._fmlyMdclInsrncInd;
            }
            set
            {
                this._fmlyMdclInsrncInd = value;
                _shouldSerializeFmlyMdclInsrncInd = true;
            }
        }

        public bool MplyeeTermntnInd
        {
            get
            {
                return this._mplyeeTermntnInd;
            }
            set
            {
                this._mplyeeTermntnInd = value;
                _shouldSerializeMplyeeTermntnInd = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(Garnishment2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Dt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDt()
        {
            if (_shouldSerializeDt)
            {
                return true;
            }
            return (_dt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether FmlyMdclInsrncInd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeFmlyMdclInsrncInd()
        {
            if (_shouldSerializeFmlyMdclInsrncInd)
            {
                return true;
            }
            return (_fmlyMdclInsrncInd != default(bool));
        }

        /// <summary>
        /// Test whether MplyeeTermntnInd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeMplyeeTermntnInd()
        {
            if (_shouldSerializeMplyeeTermntnInd)
            {
                return true;
            }
            return (_mplyeeTermntnInd != default(bool));
        }

        /// <summary>
        /// Test whether Tp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTp()
        {
            return (_tp != null);
        }

        /// <summary>
        /// Test whether Grnshee should be serialized
        /// </summary>
        public virtual bool ShouldSerializeGrnshee()
        {
            return (_grnshee != null);
        }

        /// <summary>
        /// Test whether GrnshmtAdmstr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeGrnshmtAdmstr()
        {
            return (_grnshmtAdmstr != null);
        }

        /// <summary>
        /// Test whether RmtdAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRmtdAmt()
        {
            return (_rmtdAmt != null);
        }

        /// <summary>
        /// Test whether RefNb should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRefNb()
        {
            return !string.IsNullOrEmpty(RefNb);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current Garnishment2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an Garnishment2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output Garnishment2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out Garnishment2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Garnishment2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out Garnishment2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static Garnishment2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((Garnishment2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static Garnishment2 Deserialize(System.IO.Stream s)
        {
            return ((Garnishment2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current Garnishment2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an Garnishment2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Garnishment2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Garnishment2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Garnishment2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Garnishment2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Garnishment2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class PartyIdentification125
    {

        #region Private fields
        private string _nm;

        private PostalAddress6 _pstlAdr;

        private Party34Choice _id;

        private string _ctryOfRes;

        private ContactDetails2 _ctctDtls;

        private static XmlSerializer serializer;
        #endregion

        public string Nm
        {
            get
            {
                return this._nm;
            }
            set
            {
                this._nm = value;
            }
        }

        public PostalAddress6 PstlAdr
        {
            get
            {
                return this._pstlAdr;
            }
            set
            {
                this._pstlAdr = value;
            }
        }

        public Party34Choice Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string CtryOfRes
        {
            get
            {
                return this._ctryOfRes;
            }
            set
            {
                this._ctryOfRes = value;
            }
        }

        public ContactDetails2 CtctDtls
        {
            get
            {
                return this._ctctDtls;
            }
            set
            {
                this._ctctDtls = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(PartyIdentification125));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether PstlAdr should be serialized
        /// </summary>
        public virtual bool ShouldSerializePstlAdr()
        {
            return (_pstlAdr != null);
        }

        /// <summary>
        /// Test whether Id should be serialized
        /// </summary>
        public virtual bool ShouldSerializeId()
        {
            return (_id != null);
        }

        /// <summary>
        /// Test whether CtctDtls should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtctDtls()
        {
            return (_ctctDtls != null);
        }

        /// <summary>
        /// Test whether Nm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNm()
        {
            return !string.IsNullOrEmpty(Nm);
        }

        /// <summary>
        /// Test whether CtryOfRes should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtryOfRes()
        {
            return !string.IsNullOrEmpty(CtryOfRes);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current PartyIdentification125 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an PartyIdentification125 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output PartyIdentification125 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out PartyIdentification125 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PartyIdentification125);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out PartyIdentification125 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static PartyIdentification125 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((PartyIdentification125)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static PartyIdentification125 Deserialize(System.IO.Stream s)
        {
            return ((PartyIdentification125)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current PartyIdentification125 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an PartyIdentification125 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PartyIdentification125 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PartyIdentification125 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PartyIdentification125);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out PartyIdentification125 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static PartyIdentification125 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class PostalAddress6
    {

        #region Private fields
        private bool _shouldSerializeAdrTp;

        private AddressType2Code _adrTp;

        private string _dept;

        private string _subDept;

        private string _strtNm;

        private string _bldgNb;

        private string _pstCd;

        private string _twnNm;

        private string _ctrySubDvsn;

        private string _ctry;

        private List<string> _adrLine;

        private static XmlSerializer serializer;
        #endregion

        public AddressType2Code AdrTp
        {
            get
            {
                return this._adrTp;
            }
            set
            {
                this._adrTp = value;
                _shouldSerializeAdrTp = true;
            }
        }

        public string Dept
        {
            get
            {
                return this._dept;
            }
            set
            {
                this._dept = value;
            }
        }

        public string SubDept
        {
            get
            {
                return this._subDept;
            }
            set
            {
                this._subDept = value;
            }
        }

        public string StrtNm
        {
            get
            {
                return this._strtNm;
            }
            set
            {
                this._strtNm = value;
            }
        }

        public string BldgNb
        {
            get
            {
                return this._bldgNb;
            }
            set
            {
                this._bldgNb = value;
            }
        }

        public string PstCd
        {
            get
            {
                return this._pstCd;
            }
            set
            {
                this._pstCd = value;
            }
        }

        public string TwnNm
        {
            get
            {
                return this._twnNm;
            }
            set
            {
                this._twnNm = value;
            }
        }

        public string CtrySubDvsn
        {
            get
            {
                return this._ctrySubDvsn;
            }
            set
            {
                this._ctrySubDvsn = value;
            }
        }

        public string Ctry
        {
            get
            {
                return this._ctry;
            }
            set
            {
                this._ctry = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("AdrLine")]
        public List<string> AdrLine
        {
            get
            {
                return this._adrLine;
            }
            set
            {
                this._adrLine = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(PostalAddress6));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether AdrLine should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAdrLine()
        {
            return AdrLine != null && AdrLine.Count > 0;
        }

        /// <summary>
        /// Test whether AdrTp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAdrTp()
        {
            if (_shouldSerializeAdrTp)
            {
                return true;
            }
            return (_adrTp != default(AddressType2Code));
        }

        /// <summary>
        /// Test whether Dept should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDept()
        {
            return !string.IsNullOrEmpty(Dept);
        }

        /// <summary>
        /// Test whether SubDept should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSubDept()
        {
            return !string.IsNullOrEmpty(SubDept);
        }

        /// <summary>
        /// Test whether StrtNm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeStrtNm()
        {
            return !string.IsNullOrEmpty(StrtNm);
        }

        /// <summary>
        /// Test whether BldgNb should be serialized
        /// </summary>
        public virtual bool ShouldSerializeBldgNb()
        {
            return !string.IsNullOrEmpty(BldgNb);
        }

        /// <summary>
        /// Test whether PstCd should be serialized
        /// </summary>
        public virtual bool ShouldSerializePstCd()
        {
            return !string.IsNullOrEmpty(PstCd);
        }

        /// <summary>
        /// Test whether TwnNm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTwnNm()
        {
            return !string.IsNullOrEmpty(TwnNm);
        }

        /// <summary>
        /// Test whether CtrySubDvsn should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtrySubDvsn()
        {
            return !string.IsNullOrEmpty(CtrySubDvsn);
        }

        /// <summary>
        /// Test whether Ctry should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtry()
        {
            return !string.IsNullOrEmpty(Ctry);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current PostalAddress6 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an PostalAddress6 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output PostalAddress6 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out PostalAddress6 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PostalAddress6);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out PostalAddress6 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static PostalAddress6 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((PostalAddress6)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static PostalAddress6 Deserialize(System.IO.Stream s)
        {
            return ((PostalAddress6)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current PostalAddress6 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an PostalAddress6 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PostalAddress6 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PostalAddress6 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PostalAddress6);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out PostalAddress6 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static PostalAddress6 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum AddressType2Code
    {

        /// <remarks/>
        ADDR,

        /// <remarks/>
        PBOX,

        /// <remarks/>
        HOME,

        /// <remarks/>
        BIZZ,

        /// <remarks/>
        MLTO,

        /// <remarks/>
        DLVY,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class Party34Choice
    {

        #region Private fields
        private bool _shouldSerializeItem;

        private object _item;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("OrgId", typeof(OrganisationIdentification8))]
        [System.Xml.Serialization.XmlElementAttribute("PrvtId", typeof(PersonIdentification13))]
        public object Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
                _shouldSerializeItem = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(Party34Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            if (_shouldSerializeItem)
            {
                return true;
            }
            return (_item != default(object));
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current Party34Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an Party34Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output Party34Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out Party34Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Party34Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out Party34Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static Party34Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((Party34Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static Party34Choice Deserialize(System.IO.Stream s)
        {
            return ((Party34Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current Party34Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an Party34Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Party34Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Party34Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Party34Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Party34Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Party34Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class OrganisationIdentification8
    {

        #region Private fields
        private string _anyBIC;

        private List<GenericOrganisationIdentification1> _othr;

        private static XmlSerializer serializer;
        #endregion

        public string AnyBIC
        {
            get
            {
                return this._anyBIC;
            }
            set
            {
                this._anyBIC = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Othr")]
        public List<GenericOrganisationIdentification1> Othr
        {
            get
            {
                return this._othr;
            }
            set
            {
                this._othr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(OrganisationIdentification8));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Othr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeOthr()
        {
            return Othr != null && Othr.Count > 0;
        }

        /// <summary>
        /// Test whether AnyBIC should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAnyBIC()
        {
            return !string.IsNullOrEmpty(AnyBIC);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current OrganisationIdentification8 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an OrganisationIdentification8 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output OrganisationIdentification8 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out OrganisationIdentification8 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(OrganisationIdentification8);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out OrganisationIdentification8 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static OrganisationIdentification8 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((OrganisationIdentification8)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static OrganisationIdentification8 Deserialize(System.IO.Stream s)
        {
            return ((OrganisationIdentification8)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current OrganisationIdentification8 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an OrganisationIdentification8 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output OrganisationIdentification8 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out OrganisationIdentification8 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(OrganisationIdentification8);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out OrganisationIdentification8 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static OrganisationIdentification8 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class GenericOrganisationIdentification1
    {

        #region Private fields
        private string _id;

        private OrganisationIdentificationSchemeName1Choice _schmeNm;

        private string _issr;

        private static XmlSerializer serializer;
        #endregion

        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public OrganisationIdentificationSchemeName1Choice SchmeNm
        {
            get
            {
                return this._schmeNm;
            }
            set
            {
                this._schmeNm = value;
            }
        }

        public string Issr
        {
            get
            {
                return this._issr;
            }
            set
            {
                this._issr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(GenericOrganisationIdentification1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether SchmeNm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSchmeNm()
        {
            return (_schmeNm != null);
        }

        /// <summary>
        /// Test whether Id should be serialized
        /// </summary>
        public virtual bool ShouldSerializeId()
        {
            return !string.IsNullOrEmpty(Id);
        }

        /// <summary>
        /// Test whether Issr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIssr()
        {
            return !string.IsNullOrEmpty(Issr);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current GenericOrganisationIdentification1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an GenericOrganisationIdentification1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output GenericOrganisationIdentification1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out GenericOrganisationIdentification1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GenericOrganisationIdentification1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out GenericOrganisationIdentification1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static GenericOrganisationIdentification1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((GenericOrganisationIdentification1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static GenericOrganisationIdentification1 Deserialize(System.IO.Stream s)
        {
            return ((GenericOrganisationIdentification1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current GenericOrganisationIdentification1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an GenericOrganisationIdentification1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output GenericOrganisationIdentification1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out GenericOrganisationIdentification1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GenericOrganisationIdentification1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out GenericOrganisationIdentification1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static GenericOrganisationIdentification1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class OrganisationIdentificationSchemeName1Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType8 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType8 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(OrganisationIdentificationSchemeName1Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType8));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current OrganisationIdentificationSchemeName1Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an OrganisationIdentificationSchemeName1Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output OrganisationIdentificationSchemeName1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out OrganisationIdentificationSchemeName1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(OrganisationIdentificationSchemeName1Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out OrganisationIdentificationSchemeName1Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static OrganisationIdentificationSchemeName1Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((OrganisationIdentificationSchemeName1Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static OrganisationIdentificationSchemeName1Choice Deserialize(System.IO.Stream s)
        {
            return ((OrganisationIdentificationSchemeName1Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current OrganisationIdentificationSchemeName1Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an OrganisationIdentificationSchemeName1Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output OrganisationIdentificationSchemeName1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out OrganisationIdentificationSchemeName1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(OrganisationIdentificationSchemeName1Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out OrganisationIdentificationSchemeName1Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static OrganisationIdentificationSchemeName1Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType8
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class PersonIdentification13
    {

        #region Private fields
        private DateAndPlaceOfBirth1 _dtAndPlcOfBirth;

        private List<GenericPersonIdentification1> _othr;

        private static XmlSerializer serializer;
        #endregion

        public DateAndPlaceOfBirth1 DtAndPlcOfBirth
        {
            get
            {
                return this._dtAndPlcOfBirth;
            }
            set
            {
                this._dtAndPlcOfBirth = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Othr")]
        public List<GenericPersonIdentification1> Othr
        {
            get
            {
                return this._othr;
            }
            set
            {
                this._othr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(PersonIdentification13));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Othr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeOthr()
        {
            return Othr != null && Othr.Count > 0;
        }

        /// <summary>
        /// Test whether DtAndPlcOfBirth should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDtAndPlcOfBirth()
        {
            return (_dtAndPlcOfBirth != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current PersonIdentification13 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an PersonIdentification13 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output PersonIdentification13 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out PersonIdentification13 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PersonIdentification13);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out PersonIdentification13 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static PersonIdentification13 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((PersonIdentification13)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static PersonIdentification13 Deserialize(System.IO.Stream s)
        {
            return ((PersonIdentification13)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current PersonIdentification13 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an PersonIdentification13 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PersonIdentification13 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PersonIdentification13 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PersonIdentification13);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out PersonIdentification13 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static PersonIdentification13 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class DateAndPlaceOfBirth1
    {

        #region Private fields
        private bool _shouldSerializeBirthDt;

        private System.DateTime _birthDt;

        private string _prvcOfBirth;

        private string _cityOfBirth;

        private string _ctryOfBirth;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime BirthDt
        {
            get
            {
                return this._birthDt;
            }
            set
            {
                this._birthDt = value;
                _shouldSerializeBirthDt = true;
            }
        }

        public string PrvcOfBirth
        {
            get
            {
                return this._prvcOfBirth;
            }
            set
            {
                this._prvcOfBirth = value;
            }
        }

        public string CityOfBirth
        {
            get
            {
                return this._cityOfBirth;
            }
            set
            {
                this._cityOfBirth = value;
            }
        }

        public string CtryOfBirth
        {
            get
            {
                return this._ctryOfBirth;
            }
            set
            {
                this._ctryOfBirth = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(DateAndPlaceOfBirth1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether BirthDt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeBirthDt()
        {
            if (_shouldSerializeBirthDt)
            {
                return true;
            }
            return (_birthDt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether PrvcOfBirth should be serialized
        /// </summary>
        public virtual bool ShouldSerializePrvcOfBirth()
        {
            return !string.IsNullOrEmpty(PrvcOfBirth);
        }

        /// <summary>
        /// Test whether CityOfBirth should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCityOfBirth()
        {
            return !string.IsNullOrEmpty(CityOfBirth);
        }

        /// <summary>
        /// Test whether CtryOfBirth should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtryOfBirth()
        {
            return !string.IsNullOrEmpty(CtryOfBirth);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current DateAndPlaceOfBirth1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an DateAndPlaceOfBirth1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output DateAndPlaceOfBirth1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out DateAndPlaceOfBirth1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DateAndPlaceOfBirth1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out DateAndPlaceOfBirth1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static DateAndPlaceOfBirth1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((DateAndPlaceOfBirth1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static DateAndPlaceOfBirth1 Deserialize(System.IO.Stream s)
        {
            return ((DateAndPlaceOfBirth1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current DateAndPlaceOfBirth1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an DateAndPlaceOfBirth1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DateAndPlaceOfBirth1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DateAndPlaceOfBirth1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DateAndPlaceOfBirth1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DateAndPlaceOfBirth1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DateAndPlaceOfBirth1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class GenericPersonIdentification1
    {

        #region Private fields
        private string _id;

        private PersonIdentificationSchemeName1Choice _schmeNm;

        private string _issr;

        private static XmlSerializer serializer;
        #endregion

        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public PersonIdentificationSchemeName1Choice SchmeNm
        {
            get
            {
                return this._schmeNm;
            }
            set
            {
                this._schmeNm = value;
            }
        }

        public string Issr
        {
            get
            {
                return this._issr;
            }
            set
            {
                this._issr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(GenericPersonIdentification1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether SchmeNm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSchmeNm()
        {
            return (_schmeNm != null);
        }

        /// <summary>
        /// Test whether Id should be serialized
        /// </summary>
        public virtual bool ShouldSerializeId()
        {
            return !string.IsNullOrEmpty(Id);
        }

        /// <summary>
        /// Test whether Issr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIssr()
        {
            return !string.IsNullOrEmpty(Issr);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current GenericPersonIdentification1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an GenericPersonIdentification1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output GenericPersonIdentification1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out GenericPersonIdentification1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GenericPersonIdentification1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out GenericPersonIdentification1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static GenericPersonIdentification1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((GenericPersonIdentification1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static GenericPersonIdentification1 Deserialize(System.IO.Stream s)
        {
            return ((GenericPersonIdentification1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current GenericPersonIdentification1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an GenericPersonIdentification1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output GenericPersonIdentification1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out GenericPersonIdentification1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GenericPersonIdentification1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out GenericPersonIdentification1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static GenericPersonIdentification1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class PersonIdentificationSchemeName1Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType9 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType9 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(PersonIdentificationSchemeName1Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType9));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current PersonIdentificationSchemeName1Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an PersonIdentificationSchemeName1Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output PersonIdentificationSchemeName1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out PersonIdentificationSchemeName1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PersonIdentificationSchemeName1Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out PersonIdentificationSchemeName1Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static PersonIdentificationSchemeName1Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((PersonIdentificationSchemeName1Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static PersonIdentificationSchemeName1Choice Deserialize(System.IO.Stream s)
        {
            return ((PersonIdentificationSchemeName1Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current PersonIdentificationSchemeName1Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an PersonIdentificationSchemeName1Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PersonIdentificationSchemeName1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PersonIdentificationSchemeName1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PersonIdentificationSchemeName1Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out PersonIdentificationSchemeName1Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static PersonIdentificationSchemeName1Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType9
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class ContactDetails2
    {

        #region Private fields
        private bool _shouldSerializeNmPrfx;

        private NamePrefix1Code _nmPrfx;

        private string _nm;

        private string _phneNb;

        private string _mobNb;

        private string _faxNb;

        private string _emailAdr;

        private string _othr;

        private static XmlSerializer serializer;
        #endregion

        public NamePrefix1Code NmPrfx
        {
            get
            {
                return this._nmPrfx;
            }
            set
            {
                this._nmPrfx = value;
                _shouldSerializeNmPrfx = true;
            }
        }

        public string Nm
        {
            get
            {
                return this._nm;
            }
            set
            {
                this._nm = value;
            }
        }

        public string PhneNb
        {
            get
            {
                return this._phneNb;
            }
            set
            {
                this._phneNb = value;
            }
        }

        public string MobNb
        {
            get
            {
                return this._mobNb;
            }
            set
            {
                this._mobNb = value;
            }
        }

        public string FaxNb
        {
            get
            {
                return this._faxNb;
            }
            set
            {
                this._faxNb = value;
            }
        }

        public string EmailAdr
        {
            get
            {
                return this._emailAdr;
            }
            set
            {
                this._emailAdr = value;
            }
        }

        public string Othr
        {
            get
            {
                return this._othr;
            }
            set
            {
                this._othr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(ContactDetails2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether NmPrfx should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNmPrfx()
        {
            if (_shouldSerializeNmPrfx)
            {
                return true;
            }
            return (_nmPrfx != default(NamePrefix1Code));
        }

        /// <summary>
        /// Test whether Nm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNm()
        {
            return !string.IsNullOrEmpty(Nm);
        }

        /// <summary>
        /// Test whether PhneNb should be serialized
        /// </summary>
        public virtual bool ShouldSerializePhneNb()
        {
            return !string.IsNullOrEmpty(PhneNb);
        }

        /// <summary>
        /// Test whether MobNb should be serialized
        /// </summary>
        public virtual bool ShouldSerializeMobNb()
        {
            return !string.IsNullOrEmpty(MobNb);
        }

        /// <summary>
        /// Test whether FaxNb should be serialized
        /// </summary>
        public virtual bool ShouldSerializeFaxNb()
        {
            return !string.IsNullOrEmpty(FaxNb);
        }

        /// <summary>
        /// Test whether EmailAdr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeEmailAdr()
        {
            return !string.IsNullOrEmpty(EmailAdr);
        }

        /// <summary>
        /// Test whether Othr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeOthr()
        {
            return !string.IsNullOrEmpty(Othr);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current ContactDetails2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an ContactDetails2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ContactDetails2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ContactDetails2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ContactDetails2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ContactDetails2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ContactDetails2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((ContactDetails2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ContactDetails2 Deserialize(System.IO.Stream s)
        {
            return ((ContactDetails2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ContactDetails2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ContactDetails2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ContactDetails2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ContactDetails2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ContactDetails2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ContactDetails2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ContactDetails2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum NamePrefix1Code
    {

        /// <remarks/>
        DOCT,

        /// <remarks/>
        MIST,

        /// <remarks/>
        MISS,

        /// <remarks/>
        MADM,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class ActiveOrHistoricCurrencyAndAmount
    {

        #region Private fields
        private bool _shouldSerializeValue;

        private string _ccy;

        private decimal _value;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Ccy
        {
            get
            {
                return this._ccy;
            }
            set
            {
                this._ccy = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
                _shouldSerializeValue = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(ActiveOrHistoricCurrencyAndAmount));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Value should be serialized
        /// </summary>
        public virtual bool ShouldSerializeValue()
        {
            if (_shouldSerializeValue)
            {
                return true;
            }
            return (_value != default(decimal));
        }

        /// <summary>
        /// Test whether Ccy should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCcy()
        {
            return !string.IsNullOrEmpty(Ccy);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current ActiveOrHistoricCurrencyAndAmount object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an ActiveOrHistoricCurrencyAndAmount object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ActiveOrHistoricCurrencyAndAmount object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ActiveOrHistoricCurrencyAndAmount obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ActiveOrHistoricCurrencyAndAmount);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ActiveOrHistoricCurrencyAndAmount obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ActiveOrHistoricCurrencyAndAmount Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((ActiveOrHistoricCurrencyAndAmount)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ActiveOrHistoricCurrencyAndAmount Deserialize(System.IO.Stream s)
        {
            return ((ActiveOrHistoricCurrencyAndAmount)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ActiveOrHistoricCurrencyAndAmount object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ActiveOrHistoricCurrencyAndAmount object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ActiveOrHistoricCurrencyAndAmount object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ActiveOrHistoricCurrencyAndAmount obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ActiveOrHistoricCurrencyAndAmount);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ActiveOrHistoricCurrencyAndAmount obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ActiveOrHistoricCurrencyAndAmount LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxInformation7
    {

        #region Private fields
        private bool _shouldSerializeSeqNb;

        private bool _shouldSerializeDt;

        private TaxParty1 _cdtr;

        private TaxParty2 _dbtr;

        private TaxParty2 _ultmtDbtr;

        private string _admstnZone;

        private string _refNb;

        private string _mtd;

        private ActiveOrHistoricCurrencyAndAmount _ttlTaxblBaseAmt;

        private ActiveOrHistoricCurrencyAndAmount _ttlTaxAmt;

        private System.DateTime _dt;

        private decimal _seqNb;

        private List<TaxRecord2> _rcrd;

        private static XmlSerializer serializer;
        #endregion

        public TaxParty1 Cdtr
        {
            get
            {
                return this._cdtr;
            }
            set
            {
                this._cdtr = value;
            }
        }

        public TaxParty2 Dbtr
        {
            get
            {
                return this._dbtr;
            }
            set
            {
                this._dbtr = value;
            }
        }

        public TaxParty2 UltmtDbtr
        {
            get
            {
                return this._ultmtDbtr;
            }
            set
            {
                this._ultmtDbtr = value;
            }
        }

        public string AdmstnZone
        {
            get
            {
                return this._admstnZone;
            }
            set
            {
                this._admstnZone = value;
            }
        }

        public string RefNb
        {
            get
            {
                return this._refNb;
            }
            set
            {
                this._refNb = value;
            }
        }

        public string Mtd
        {
            get
            {
                return this._mtd;
            }
            set
            {
                this._mtd = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount TtlTaxblBaseAmt
        {
            get
            {
                return this._ttlTaxblBaseAmt;
            }
            set
            {
                this._ttlTaxblBaseAmt = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount TtlTaxAmt
        {
            get
            {
                return this._ttlTaxAmt;
            }
            set
            {
                this._ttlTaxAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime Dt
        {
            get
            {
                return this._dt;
            }
            set
            {
                this._dt = value;
                _shouldSerializeDt = true;
            }
        }

        public decimal SeqNb
        {
            get
            {
                return this._seqNb;
            }
            set
            {
                this._seqNb = value;
                _shouldSerializeSeqNb = true;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Rcrd")]
        public List<TaxRecord2> Rcrd
        {
            get
            {
                return this._rcrd;
            }
            set
            {
                this._rcrd = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxInformation7));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Rcrd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRcrd()
        {
            return Rcrd != null && Rcrd.Count > 0;
        }

        /// <summary>
        /// Test whether Dt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDt()
        {
            if (_shouldSerializeDt)
            {
                return true;
            }
            return (_dt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether SeqNb should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSeqNb()
        {
            if (_shouldSerializeSeqNb)
            {
                return true;
            }
            return (_seqNb != default(decimal));
        }

        /// <summary>
        /// Test whether Cdtr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtr()
        {
            return (_cdtr != null);
        }

        /// <summary>
        /// Test whether Dbtr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDbtr()
        {
            return (_dbtr != null);
        }

        /// <summary>
        /// Test whether UltmtDbtr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeUltmtDbtr()
        {
            return (_ultmtDbtr != null);
        }

        /// <summary>
        /// Test whether TtlTaxblBaseAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTtlTaxblBaseAmt()
        {
            return (_ttlTaxblBaseAmt != null);
        }

        /// <summary>
        /// Test whether TtlTaxAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTtlTaxAmt()
        {
            return (_ttlTaxAmt != null);
        }

        /// <summary>
        /// Test whether AdmstnZone should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAdmstnZone()
        {
            return !string.IsNullOrEmpty(AdmstnZone);
        }

        /// <summary>
        /// Test whether RefNb should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRefNb()
        {
            return !string.IsNullOrEmpty(RefNb);
        }

        /// <summary>
        /// Test whether Mtd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeMtd()
        {
            return !string.IsNullOrEmpty(Mtd);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxInformation7 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxInformation7 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxInformation7 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxInformation7 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxInformation7);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxInformation7 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxInformation7 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxInformation7)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxInformation7 Deserialize(System.IO.Stream s)
        {
            return ((TaxInformation7)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxInformation7 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxInformation7 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxInformation7 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxInformation7 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxInformation7);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxInformation7 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxInformation7 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxParty1
    {

        #region Private fields
        private string _taxId;

        private string _regnId;

        private string _taxTp;

        private static XmlSerializer serializer;
        #endregion

        public string TaxId
        {
            get
            {
                return this._taxId;
            }
            set
            {
                this._taxId = value;
            }
        }

        public string RegnId
        {
            get
            {
                return this._regnId;
            }
            set
            {
                this._regnId = value;
            }
        }

        public string TaxTp
        {
            get
            {
                return this._taxTp;
            }
            set
            {
                this._taxTp = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxParty1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether TaxId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTaxId()
        {
            return !string.IsNullOrEmpty(TaxId);
        }

        /// <summary>
        /// Test whether RegnId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRegnId()
        {
            return !string.IsNullOrEmpty(RegnId);
        }

        /// <summary>
        /// Test whether TaxTp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTaxTp()
        {
            return !string.IsNullOrEmpty(TaxTp);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxParty1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxParty1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxParty1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxParty1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxParty1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxParty1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxParty1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxParty1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxParty1 Deserialize(System.IO.Stream s)
        {
            return ((TaxParty1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxParty1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxParty1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxParty1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxParty1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxParty1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxParty1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxParty1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxParty2
    {

        #region Private fields
        private string _taxId;

        private string _regnId;

        private string _taxTp;

        private TaxAuthorisation1 _authstn;

        private static XmlSerializer serializer;
        #endregion

        public string TaxId
        {
            get
            {
                return this._taxId;
            }
            set
            {
                this._taxId = value;
            }
        }

        public string RegnId
        {
            get
            {
                return this._regnId;
            }
            set
            {
                this._regnId = value;
            }
        }

        public string TaxTp
        {
            get
            {
                return this._taxTp;
            }
            set
            {
                this._taxTp = value;
            }
        }

        public TaxAuthorisation1 Authstn
        {
            get
            {
                return this._authstn;
            }
            set
            {
                this._authstn = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxParty2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Authstn should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAuthstn()
        {
            return (_authstn != null);
        }

        /// <summary>
        /// Test whether TaxId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTaxId()
        {
            return !string.IsNullOrEmpty(TaxId);
        }

        /// <summary>
        /// Test whether RegnId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRegnId()
        {
            return !string.IsNullOrEmpty(RegnId);
        }

        /// <summary>
        /// Test whether TaxTp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTaxTp()
        {
            return !string.IsNullOrEmpty(TaxTp);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxParty2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxParty2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxParty2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxParty2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxParty2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxParty2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxParty2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxParty2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxParty2 Deserialize(System.IO.Stream s)
        {
            return ((TaxParty2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxParty2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxParty2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxParty2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxParty2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxParty2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxParty2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxParty2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxAuthorisation1
    {

        #region Private fields
        private string _titl;

        private string _nm;

        private static XmlSerializer serializer;
        #endregion

        public string Titl
        {
            get
            {
                return this._titl;
            }
            set
            {
                this._titl = value;
            }
        }

        public string Nm
        {
            get
            {
                return this._nm;
            }
            set
            {
                this._nm = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxAuthorisation1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Titl should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTitl()
        {
            return !string.IsNullOrEmpty(Titl);
        }

        /// <summary>
        /// Test whether Nm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNm()
        {
            return !string.IsNullOrEmpty(Nm);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxAuthorisation1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxAuthorisation1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxAuthorisation1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxAuthorisation1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxAuthorisation1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxAuthorisation1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxAuthorisation1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxAuthorisation1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxAuthorisation1 Deserialize(System.IO.Stream s)
        {
            return ((TaxAuthorisation1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxAuthorisation1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxAuthorisation1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxAuthorisation1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxAuthorisation1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxAuthorisation1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxAuthorisation1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxAuthorisation1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxRecord2
    {

        #region Private fields
        private string _tp;

        private string _ctgy;

        private string _ctgyDtls;

        private string _dbtrSts;

        private string _certId;

        private string _frmsCd;

        private TaxPeriod2 _prd;

        private TaxAmount2 _taxAmt;

        private string _addtlInf;

        private static XmlSerializer serializer;
        #endregion

        public string Tp
        {
            get
            {
                return this._tp;
            }
            set
            {
                this._tp = value;
            }
        }

        public string Ctgy
        {
            get
            {
                return this._ctgy;
            }
            set
            {
                this._ctgy = value;
            }
        }

        public string CtgyDtls
        {
            get
            {
                return this._ctgyDtls;
            }
            set
            {
                this._ctgyDtls = value;
            }
        }

        public string DbtrSts
        {
            get
            {
                return this._dbtrSts;
            }
            set
            {
                this._dbtrSts = value;
            }
        }

        public string CertId
        {
            get
            {
                return this._certId;
            }
            set
            {
                this._certId = value;
            }
        }

        public string FrmsCd
        {
            get
            {
                return this._frmsCd;
            }
            set
            {
                this._frmsCd = value;
            }
        }

        public TaxPeriod2 Prd
        {
            get
            {
                return this._prd;
            }
            set
            {
                this._prd = value;
            }
        }

        public TaxAmount2 TaxAmt
        {
            get
            {
                return this._taxAmt;
            }
            set
            {
                this._taxAmt = value;
            }
        }

        public string AddtlInf
        {
            get
            {
                return this._addtlInf;
            }
            set
            {
                this._addtlInf = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxRecord2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Prd should be serialized
        /// </summary>
        public virtual bool ShouldSerializePrd()
        {
            return (_prd != null);
        }

        /// <summary>
        /// Test whether TaxAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTaxAmt()
        {
            return (_taxAmt != null);
        }

        /// <summary>
        /// Test whether Tp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTp()
        {
            return !string.IsNullOrEmpty(Tp);
        }

        /// <summary>
        /// Test whether Ctgy should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtgy()
        {
            return !string.IsNullOrEmpty(Ctgy);
        }

        /// <summary>
        /// Test whether CtgyDtls should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtgyDtls()
        {
            return !string.IsNullOrEmpty(CtgyDtls);
        }

        /// <summary>
        /// Test whether DbtrSts should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDbtrSts()
        {
            return !string.IsNullOrEmpty(DbtrSts);
        }

        /// <summary>
        /// Test whether CertId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCertId()
        {
            return !string.IsNullOrEmpty(CertId);
        }

        /// <summary>
        /// Test whether FrmsCd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeFrmsCd()
        {
            return !string.IsNullOrEmpty(FrmsCd);
        }

        /// <summary>
        /// Test whether AddtlInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAddtlInf()
        {
            return !string.IsNullOrEmpty(AddtlInf);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxRecord2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxRecord2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxRecord2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxRecord2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxRecord2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxRecord2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxRecord2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxRecord2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxRecord2 Deserialize(System.IO.Stream s)
        {
            return ((TaxRecord2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxRecord2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxRecord2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxRecord2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxRecord2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxRecord2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxRecord2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxRecord2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxPeriod2
    {

        #region Private fields
        private bool _shouldSerializeTp;

        private bool _shouldSerializeYr;

        private System.DateTime _yr;

        private TaxRecordPeriod1Code _tp;

        private DatePeriod2 _frToDt;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime Yr
        {
            get
            {
                return this._yr;
            }
            set
            {
                this._yr = value;
                _shouldSerializeYr = true;
            }
        }

        public TaxRecordPeriod1Code Tp
        {
            get
            {
                return this._tp;
            }
            set
            {
                this._tp = value;
                _shouldSerializeTp = true;
            }
        }

        public DatePeriod2 FrToDt
        {
            get
            {
                return this._frToDt;
            }
            set
            {
                this._frToDt = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxPeriod2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Yr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeYr()
        {
            if (_shouldSerializeYr)
            {
                return true;
            }
            return (_yr != default(System.DateTime));
        }

        /// <summary>
        /// Test whether Tp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTp()
        {
            if (_shouldSerializeTp)
            {
                return true;
            }
            return (_tp != default(TaxRecordPeriod1Code));
        }

        /// <summary>
        /// Test whether FrToDt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeFrToDt()
        {
            return (_frToDt != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxPeriod2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxPeriod2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxPeriod2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxPeriod2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxPeriod2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxPeriod2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxPeriod2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxPeriod2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxPeriod2 Deserialize(System.IO.Stream s)
        {
            return ((TaxPeriod2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxPeriod2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxPeriod2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxPeriod2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxPeriod2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxPeriod2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxPeriod2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxPeriod2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum TaxRecordPeriod1Code
    {

        /// <remarks/>
        MM01,

        /// <remarks/>
        MM02,

        /// <remarks/>
        MM03,

        /// <remarks/>
        MM04,

        /// <remarks/>
        MM05,

        /// <remarks/>
        MM06,

        /// <remarks/>
        MM07,

        /// <remarks/>
        MM08,

        /// <remarks/>
        MM09,

        /// <remarks/>
        MM10,

        /// <remarks/>
        MM11,

        /// <remarks/>
        MM12,

        /// <remarks/>
        QTR1,

        /// <remarks/>
        QTR2,

        /// <remarks/>
        QTR3,

        /// <remarks/>
        QTR4,

        /// <remarks/>
        HLF1,

        /// <remarks/>
        HLF2,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class DatePeriod2
    {

        #region Private fields
        private bool _shouldSerializeToDt;

        private bool _shouldSerializeFrDt;

        private System.DateTime _frDt;

        private System.DateTime _toDt;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime FrDt
        {
            get
            {
                return this._frDt;
            }
            set
            {
                this._frDt = value;
                _shouldSerializeFrDt = true;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime ToDt
        {
            get
            {
                return this._toDt;
            }
            set
            {
                this._toDt = value;
                _shouldSerializeToDt = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(DatePeriod2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether FrDt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeFrDt()
        {
            if (_shouldSerializeFrDt)
            {
                return true;
            }
            return (_frDt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether ToDt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeToDt()
        {
            if (_shouldSerializeToDt)
            {
                return true;
            }
            return (_toDt != default(System.DateTime));
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current DatePeriod2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an DatePeriod2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output DatePeriod2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out DatePeriod2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DatePeriod2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out DatePeriod2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static DatePeriod2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((DatePeriod2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static DatePeriod2 Deserialize(System.IO.Stream s)
        {
            return ((DatePeriod2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current DatePeriod2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an DatePeriod2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DatePeriod2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DatePeriod2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DatePeriod2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DatePeriod2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DatePeriod2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxAmount2
    {

        #region Private fields
        private bool _shouldSerializeRate;

        private decimal _rate;

        private ActiveOrHistoricCurrencyAndAmount _taxblBaseAmt;

        private ActiveOrHistoricCurrencyAndAmount _ttlAmt;

        private List<TaxRecordDetails2> _dtls;

        private static XmlSerializer serializer;
        #endregion

        public decimal Rate
        {
            get
            {
                return this._rate;
            }
            set
            {
                this._rate = value;
                _shouldSerializeRate = true;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount TaxblBaseAmt
        {
            get
            {
                return this._taxblBaseAmt;
            }
            set
            {
                this._taxblBaseAmt = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount TtlAmt
        {
            get
            {
                return this._ttlAmt;
            }
            set
            {
                this._ttlAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Dtls")]
        public List<TaxRecordDetails2> Dtls
        {
            get
            {
                return this._dtls;
            }
            set
            {
                this._dtls = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxAmount2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Dtls should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDtls()
        {
            return Dtls != null && Dtls.Count > 0;
        }

        /// <summary>
        /// Test whether Rate should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRate()
        {
            if (_shouldSerializeRate)
            {
                return true;
            }
            return (_rate != default(decimal));
        }

        /// <summary>
        /// Test whether TaxblBaseAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTaxblBaseAmt()
        {
            return (_taxblBaseAmt != null);
        }

        /// <summary>
        /// Test whether TtlAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTtlAmt()
        {
            return (_ttlAmt != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxAmount2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxAmount2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxAmount2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxAmount2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxAmount2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxAmount2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxAmount2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxAmount2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxAmount2 Deserialize(System.IO.Stream s)
        {
            return ((TaxAmount2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxAmount2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxAmount2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxAmount2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxAmount2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxAmount2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxAmount2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxAmount2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxRecordDetails2
    {

        #region Private fields
        private TaxPeriod2 _prd;

        private ActiveOrHistoricCurrencyAndAmount _amt;

        private static XmlSerializer serializer;
        #endregion

        public TaxPeriod2 Prd
        {
            get
            {
                return this._prd;
            }
            set
            {
                this._prd = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount Amt
        {
            get
            {
                return this._amt;
            }
            set
            {
                this._amt = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxRecordDetails2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Prd should be serialized
        /// </summary>
        public virtual bool ShouldSerializePrd()
        {
            return (_prd != null);
        }

        /// <summary>
        /// Test whether Amt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAmt()
        {
            return (_amt != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxRecordDetails2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxRecordDetails2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxRecordDetails2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxRecordDetails2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxRecordDetails2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxRecordDetails2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxRecordDetails2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxRecordDetails2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxRecordDetails2 Deserialize(System.IO.Stream s)
        {
            return ((TaxRecordDetails2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxRecordDetails2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxRecordDetails2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxRecordDetails2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxRecordDetails2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxRecordDetails2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxRecordDetails2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxRecordDetails2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class CreditorReferenceType1Choice
    {

        #region Private fields
        private bool _shouldSerializeItem;

        private object _item;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd", typeof(DocumentType3Code))]
        [System.Xml.Serialization.XmlElementAttribute("Prtry", typeof(string))]
        public object Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
                _shouldSerializeItem = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(CreditorReferenceType1Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            if (_shouldSerializeItem)
            {
                return true;
            }
            return (_item != default(object));
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CreditorReferenceType1Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an CreditorReferenceType1Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CreditorReferenceType1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CreditorReferenceType1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CreditorReferenceType1Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out CreditorReferenceType1Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static CreditorReferenceType1Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CreditorReferenceType1Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CreditorReferenceType1Choice Deserialize(System.IO.Stream s)
        {
            return ((CreditorReferenceType1Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current CreditorReferenceType1Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an CreditorReferenceType1Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output CreditorReferenceType1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out CreditorReferenceType1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CreditorReferenceType1Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out CreditorReferenceType1Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static CreditorReferenceType1Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum DocumentType3Code
    {

        /// <remarks/>
        RADM,

        /// <remarks/>
        RPIN,

        /// <remarks/>
        FXDR,

        /// <remarks/>
        DISP,

        /// <remarks/>
        PUOR,

        /// <remarks/>
        SCOR,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class CreditorReferenceType2
    {

        #region Private fields
        private CreditorReferenceType1Choice _cdOrPrtry;

        private string _issr;

        private static XmlSerializer serializer;
        #endregion

        public CreditorReferenceType1Choice CdOrPrtry
        {
            get
            {
                return this._cdOrPrtry;
            }
            set
            {
                this._cdOrPrtry = value;
            }
        }

        public string Issr
        {
            get
            {
                return this._issr;
            }
            set
            {
                this._issr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(CreditorReferenceType2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether CdOrPrtry should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdOrPrtry()
        {
            return (_cdOrPrtry != null);
        }

        /// <summary>
        /// Test whether Issr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIssr()
        {
            return !string.IsNullOrEmpty(Issr);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CreditorReferenceType2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an CreditorReferenceType2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CreditorReferenceType2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CreditorReferenceType2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CreditorReferenceType2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out CreditorReferenceType2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static CreditorReferenceType2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CreditorReferenceType2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CreditorReferenceType2 Deserialize(System.IO.Stream s)
        {
            return ((CreditorReferenceType2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current CreditorReferenceType2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an CreditorReferenceType2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output CreditorReferenceType2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out CreditorReferenceType2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CreditorReferenceType2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out CreditorReferenceType2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static CreditorReferenceType2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class CreditorReferenceInformation2
    {

        #region Private fields
        private CreditorReferenceType2 _tp;

        private string _ref;

        private static XmlSerializer serializer;
        #endregion

        public CreditorReferenceType2 Tp
        {
            get
            {
                return this._tp;
            }
            set
            {
                this._tp = value;
            }
        }

        public string Ref
        {
            get
            {
                return this._ref;
            }
            set
            {
                this._ref = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(CreditorReferenceInformation2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Tp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTp()
        {
            return (_tp != null);
        }

        /// <summary>
        /// Test whether Ref should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRef()
        {
            return !string.IsNullOrEmpty(Ref);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CreditorReferenceInformation2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an CreditorReferenceInformation2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CreditorReferenceInformation2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CreditorReferenceInformation2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CreditorReferenceInformation2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out CreditorReferenceInformation2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static CreditorReferenceInformation2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CreditorReferenceInformation2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CreditorReferenceInformation2 Deserialize(System.IO.Stream s)
        {
            return ((CreditorReferenceInformation2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current CreditorReferenceInformation2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an CreditorReferenceInformation2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output CreditorReferenceInformation2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out CreditorReferenceInformation2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CreditorReferenceInformation2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out CreditorReferenceInformation2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static CreditorReferenceInformation2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class RemittanceAmount2
    {

        #region Private fields
        private ActiveOrHistoricCurrencyAndAmount _duePyblAmt;

        private List<DiscountAmountAndType1> _dscntApldAmt;

        private ActiveOrHistoricCurrencyAndAmount _cdtNoteAmt;

        private List<TaxAmountAndType1> _taxAmt;

        private List<DocumentAdjustment1> _adjstmntAmtAndRsn;

        private ActiveOrHistoricCurrencyAndAmount _rmtdAmt;

        private static XmlSerializer serializer;
        #endregion

        public ActiveOrHistoricCurrencyAndAmount DuePyblAmt
        {
            get
            {
                return this._duePyblAmt;
            }
            set
            {
                this._duePyblAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("DscntApldAmt")]
        public List<DiscountAmountAndType1> DscntApldAmt
        {
            get
            {
                return this._dscntApldAmt;
            }
            set
            {
                this._dscntApldAmt = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount CdtNoteAmt
        {
            get
            {
                return this._cdtNoteAmt;
            }
            set
            {
                this._cdtNoteAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("TaxAmt")]
        public List<TaxAmountAndType1> TaxAmt
        {
            get
            {
                return this._taxAmt;
            }
            set
            {
                this._taxAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("AdjstmntAmtAndRsn")]
        public List<DocumentAdjustment1> AdjstmntAmtAndRsn
        {
            get
            {
                return this._adjstmntAmtAndRsn;
            }
            set
            {
                this._adjstmntAmtAndRsn = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount RmtdAmt
        {
            get
            {
                return this._rmtdAmt;
            }
            set
            {
                this._rmtdAmt = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(RemittanceAmount2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether DscntApldAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDscntApldAmt()
        {
            return DscntApldAmt != null && DscntApldAmt.Count > 0;
        }

        /// <summary>
        /// Test whether TaxAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTaxAmt()
        {
            return TaxAmt != null && TaxAmt.Count > 0;
        }

        /// <summary>
        /// Test whether AdjstmntAmtAndRsn should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAdjstmntAmtAndRsn()
        {
            return AdjstmntAmtAndRsn != null && AdjstmntAmtAndRsn.Count > 0;
        }

        /// <summary>
        /// Test whether DuePyblAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDuePyblAmt()
        {
            return (_duePyblAmt != null);
        }

        /// <summary>
        /// Test whether CdtNoteAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtNoteAmt()
        {
            return (_cdtNoteAmt != null);
        }

        /// <summary>
        /// Test whether RmtdAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRmtdAmt()
        {
            return (_rmtdAmt != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current RemittanceAmount2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an RemittanceAmount2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output RemittanceAmount2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out RemittanceAmount2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RemittanceAmount2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out RemittanceAmount2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static RemittanceAmount2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((RemittanceAmount2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static RemittanceAmount2 Deserialize(System.IO.Stream s)
        {
            return ((RemittanceAmount2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current RemittanceAmount2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an RemittanceAmount2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output RemittanceAmount2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out RemittanceAmount2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RemittanceAmount2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out RemittanceAmount2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static RemittanceAmount2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class DiscountAmountAndType1
    {

        #region Private fields
        private DiscountAmountType1Choice _tp;

        private ActiveOrHistoricCurrencyAndAmount _amt;

        private static XmlSerializer serializer;
        #endregion

        public DiscountAmountType1Choice Tp
        {
            get
            {
                return this._tp;
            }
            set
            {
                this._tp = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount Amt
        {
            get
            {
                return this._amt;
            }
            set
            {
                this._amt = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(DiscountAmountAndType1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Tp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTp()
        {
            return (_tp != null);
        }

        /// <summary>
        /// Test whether Amt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAmt()
        {
            return (_amt != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current DiscountAmountAndType1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an DiscountAmountAndType1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output DiscountAmountAndType1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out DiscountAmountAndType1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DiscountAmountAndType1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out DiscountAmountAndType1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static DiscountAmountAndType1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((DiscountAmountAndType1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static DiscountAmountAndType1 Deserialize(System.IO.Stream s)
        {
            return ((DiscountAmountAndType1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current DiscountAmountAndType1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an DiscountAmountAndType1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DiscountAmountAndType1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DiscountAmountAndType1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DiscountAmountAndType1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DiscountAmountAndType1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DiscountAmountAndType1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class DiscountAmountType1Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType12 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType12 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(DiscountAmountType1Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType12));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current DiscountAmountType1Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an DiscountAmountType1Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output DiscountAmountType1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out DiscountAmountType1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DiscountAmountType1Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out DiscountAmountType1Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static DiscountAmountType1Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((DiscountAmountType1Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static DiscountAmountType1Choice Deserialize(System.IO.Stream s)
        {
            return ((DiscountAmountType1Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current DiscountAmountType1Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an DiscountAmountType1Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DiscountAmountType1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DiscountAmountType1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DiscountAmountType1Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DiscountAmountType1Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DiscountAmountType1Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType12
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxAmountAndType1
    {

        #region Private fields
        private TaxAmountType1Choice _tp;

        private ActiveOrHistoricCurrencyAndAmount _amt;

        private static XmlSerializer serializer;
        #endregion

        public TaxAmountType1Choice Tp
        {
            get
            {
                return this._tp;
            }
            set
            {
                this._tp = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount Amt
        {
            get
            {
                return this._amt;
            }
            set
            {
                this._amt = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxAmountAndType1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Tp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTp()
        {
            return (_tp != null);
        }

        /// <summary>
        /// Test whether Amt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAmt()
        {
            return (_amt != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxAmountAndType1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxAmountAndType1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxAmountAndType1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxAmountAndType1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxAmountAndType1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxAmountAndType1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxAmountAndType1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxAmountAndType1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxAmountAndType1 Deserialize(System.IO.Stream s)
        {
            return ((TaxAmountAndType1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxAmountAndType1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxAmountAndType1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxAmountAndType1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxAmountAndType1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxAmountAndType1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxAmountAndType1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxAmountAndType1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxAmountType1Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType13 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType13 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxAmountType1Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType13));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxAmountType1Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxAmountType1Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxAmountType1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxAmountType1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxAmountType1Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxAmountType1Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxAmountType1Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxAmountType1Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxAmountType1Choice Deserialize(System.IO.Stream s)
        {
            return ((TaxAmountType1Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxAmountType1Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxAmountType1Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxAmountType1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxAmountType1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxAmountType1Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxAmountType1Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxAmountType1Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType13
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class DocumentAdjustment1
    {

        #region Private fields
        private bool _shouldSerializeCdtDbtInd;

        private ActiveOrHistoricCurrencyAndAmount _amt;

        private CreditDebitCode _cdtDbtInd;

        private string _rsn;

        private string _addtlInf;

        private static XmlSerializer serializer;
        #endregion

        public ActiveOrHistoricCurrencyAndAmount Amt
        {
            get
            {
                return this._amt;
            }
            set
            {
                this._amt = value;
            }
        }

        public CreditDebitCode CdtDbtInd
        {
            get
            {
                return this._cdtDbtInd;
            }
            set
            {
                this._cdtDbtInd = value;
                _shouldSerializeCdtDbtInd = true;
            }
        }

        public string Rsn
        {
            get
            {
                return this._rsn;
            }
            set
            {
                this._rsn = value;
            }
        }

        public string AddtlInf
        {
            get
            {
                return this._addtlInf;
            }
            set
            {
                this._addtlInf = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(DocumentAdjustment1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether CdtDbtInd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtDbtInd()
        {
            if (_shouldSerializeCdtDbtInd)
            {
                return true;
            }
            return (_cdtDbtInd != default(CreditDebitCode));
        }

        /// <summary>
        /// Test whether Amt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAmt()
        {
            return (_amt != null);
        }

        /// <summary>
        /// Test whether Rsn should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRsn()
        {
            return !string.IsNullOrEmpty(Rsn);
        }

        /// <summary>
        /// Test whether AddtlInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAddtlInf()
        {
            return !string.IsNullOrEmpty(AddtlInf);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current DocumentAdjustment1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an DocumentAdjustment1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output DocumentAdjustment1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out DocumentAdjustment1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DocumentAdjustment1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out DocumentAdjustment1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static DocumentAdjustment1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((DocumentAdjustment1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static DocumentAdjustment1 Deserialize(System.IO.Stream s)
        {
            return ((DocumentAdjustment1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current DocumentAdjustment1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an DocumentAdjustment1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DocumentAdjustment1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DocumentAdjustment1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DocumentAdjustment1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DocumentAdjustment1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DocumentAdjustment1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum CreditDebitCode
    {

        /// <remarks/>
        CRDT,

        /// <remarks/>
        DBIT,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class RemittanceAmount3
    {

        #region Private fields
        private ActiveOrHistoricCurrencyAndAmount _duePyblAmt;

        private List<DiscountAmountAndType1> _dscntApldAmt;

        private ActiveOrHistoricCurrencyAndAmount _cdtNoteAmt;

        private List<TaxAmountAndType1> _taxAmt;

        private List<DocumentAdjustment1> _adjstmntAmtAndRsn;

        private ActiveOrHistoricCurrencyAndAmount _rmtdAmt;

        private static XmlSerializer serializer;
        #endregion

        public ActiveOrHistoricCurrencyAndAmount DuePyblAmt
        {
            get
            {
                return this._duePyblAmt;
            }
            set
            {
                this._duePyblAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("DscntApldAmt")]
        public List<DiscountAmountAndType1> DscntApldAmt
        {
            get
            {
                return this._dscntApldAmt;
            }
            set
            {
                this._dscntApldAmt = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount CdtNoteAmt
        {
            get
            {
                return this._cdtNoteAmt;
            }
            set
            {
                this._cdtNoteAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("TaxAmt")]
        public List<TaxAmountAndType1> TaxAmt
        {
            get
            {
                return this._taxAmt;
            }
            set
            {
                this._taxAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("AdjstmntAmtAndRsn")]
        public List<DocumentAdjustment1> AdjstmntAmtAndRsn
        {
            get
            {
                return this._adjstmntAmtAndRsn;
            }
            set
            {
                this._adjstmntAmtAndRsn = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount RmtdAmt
        {
            get
            {
                return this._rmtdAmt;
            }
            set
            {
                this._rmtdAmt = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(RemittanceAmount3));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether DscntApldAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDscntApldAmt()
        {
            return DscntApldAmt != null && DscntApldAmt.Count > 0;
        }

        /// <summary>
        /// Test whether TaxAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTaxAmt()
        {
            return TaxAmt != null && TaxAmt.Count > 0;
        }

        /// <summary>
        /// Test whether AdjstmntAmtAndRsn should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAdjstmntAmtAndRsn()
        {
            return AdjstmntAmtAndRsn != null && AdjstmntAmtAndRsn.Count > 0;
        }

        /// <summary>
        /// Test whether DuePyblAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDuePyblAmt()
        {
            return (_duePyblAmt != null);
        }

        /// <summary>
        /// Test whether CdtNoteAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtNoteAmt()
        {
            return (_cdtNoteAmt != null);
        }

        /// <summary>
        /// Test whether RmtdAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRmtdAmt()
        {
            return (_rmtdAmt != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current RemittanceAmount3 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an RemittanceAmount3 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output RemittanceAmount3 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out RemittanceAmount3 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RemittanceAmount3);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out RemittanceAmount3 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static RemittanceAmount3 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((RemittanceAmount3)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static RemittanceAmount3 Deserialize(System.IO.Stream s)
        {
            return ((RemittanceAmount3)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current RemittanceAmount3 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an RemittanceAmount3 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output RemittanceAmount3 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out RemittanceAmount3 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RemittanceAmount3);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out RemittanceAmount3 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static RemittanceAmount3 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class DocumentLineType1Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType11 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType11 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(DocumentLineType1Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType11));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current DocumentLineType1Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an DocumentLineType1Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output DocumentLineType1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out DocumentLineType1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DocumentLineType1Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out DocumentLineType1Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static DocumentLineType1Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((DocumentLineType1Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static DocumentLineType1Choice Deserialize(System.IO.Stream s)
        {
            return ((DocumentLineType1Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current DocumentLineType1Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an DocumentLineType1Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DocumentLineType1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DocumentLineType1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DocumentLineType1Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DocumentLineType1Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DocumentLineType1Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType11
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class DocumentLineType1
    {

        #region Private fields
        private DocumentLineType1Choice _cdOrPrtry;

        private string _issr;

        private static XmlSerializer serializer;
        #endregion

        public DocumentLineType1Choice CdOrPrtry
        {
            get
            {
                return this._cdOrPrtry;
            }
            set
            {
                this._cdOrPrtry = value;
            }
        }

        public string Issr
        {
            get
            {
                return this._issr;
            }
            set
            {
                this._issr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(DocumentLineType1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether CdOrPrtry should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdOrPrtry()
        {
            return (_cdOrPrtry != null);
        }

        /// <summary>
        /// Test whether Issr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIssr()
        {
            return !string.IsNullOrEmpty(Issr);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current DocumentLineType1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an DocumentLineType1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output DocumentLineType1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out DocumentLineType1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DocumentLineType1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out DocumentLineType1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static DocumentLineType1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((DocumentLineType1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static DocumentLineType1 Deserialize(System.IO.Stream s)
        {
            return ((DocumentLineType1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current DocumentLineType1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an DocumentLineType1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DocumentLineType1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DocumentLineType1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DocumentLineType1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DocumentLineType1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DocumentLineType1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class DocumentLineIdentification1
    {

        #region Private fields
        private bool _shouldSerializeRltdDt;

        private DocumentLineType1 _tp;

        private string _nb;

        private System.DateTime _rltdDt;

        private static XmlSerializer serializer;
        #endregion

        public DocumentLineType1 Tp
        {
            get
            {
                return this._tp;
            }
            set
            {
                this._tp = value;
            }
        }

        public string Nb
        {
            get
            {
                return this._nb;
            }
            set
            {
                this._nb = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime RltdDt
        {
            get
            {
                return this._rltdDt;
            }
            set
            {
                this._rltdDt = value;
                _shouldSerializeRltdDt = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(DocumentLineIdentification1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether RltdDt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRltdDt()
        {
            if (_shouldSerializeRltdDt)
            {
                return true;
            }
            return (_rltdDt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether Tp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTp()
        {
            return (_tp != null);
        }

        /// <summary>
        /// Test whether Nb should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNb()
        {
            return !string.IsNullOrEmpty(Nb);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current DocumentLineIdentification1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an DocumentLineIdentification1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output DocumentLineIdentification1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out DocumentLineIdentification1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DocumentLineIdentification1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out DocumentLineIdentification1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static DocumentLineIdentification1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((DocumentLineIdentification1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static DocumentLineIdentification1 Deserialize(System.IO.Stream s)
        {
            return ((DocumentLineIdentification1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current DocumentLineIdentification1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an DocumentLineIdentification1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DocumentLineIdentification1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DocumentLineIdentification1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DocumentLineIdentification1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DocumentLineIdentification1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DocumentLineIdentification1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class DocumentLineInformation1
    {

        #region Private fields
        private List<DocumentLineIdentification1> _id;

        private string _desc;

        private RemittanceAmount3 _amt;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Id")]
        public List<DocumentLineIdentification1> Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string Desc
        {
            get
            {
                return this._desc;
            }
            set
            {
                this._desc = value;
            }
        }

        public RemittanceAmount3 Amt
        {
            get
            {
                return this._amt;
            }
            set
            {
                this._amt = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(DocumentLineInformation1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Id should be serialized
        /// </summary>
        public virtual bool ShouldSerializeId()
        {
            return Id != null && Id.Count > 0;
        }

        /// <summary>
        /// Test whether Amt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAmt()
        {
            return (_amt != null);
        }

        /// <summary>
        /// Test whether Desc should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDesc()
        {
            return !string.IsNullOrEmpty(Desc);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current DocumentLineInformation1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an DocumentLineInformation1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output DocumentLineInformation1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out DocumentLineInformation1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DocumentLineInformation1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out DocumentLineInformation1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static DocumentLineInformation1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((DocumentLineInformation1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static DocumentLineInformation1 Deserialize(System.IO.Stream s)
        {
            return ((DocumentLineInformation1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current DocumentLineInformation1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an DocumentLineInformation1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output DocumentLineInformation1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DocumentLineInformation1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(DocumentLineInformation1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DocumentLineInformation1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static DocumentLineInformation1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class ReferredDocumentType3Choice
    {

        #region Private fields
        private bool _shouldSerializeItem;

        private object _item;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd", typeof(DocumentType6Code))]
        [System.Xml.Serialization.XmlElementAttribute("Prtry", typeof(string))]
        public object Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
                _shouldSerializeItem = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(ReferredDocumentType3Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            if (_shouldSerializeItem)
            {
                return true;
            }
            return (_item != default(object));
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current ReferredDocumentType3Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an ReferredDocumentType3Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ReferredDocumentType3Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ReferredDocumentType3Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ReferredDocumentType3Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ReferredDocumentType3Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ReferredDocumentType3Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((ReferredDocumentType3Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ReferredDocumentType3Choice Deserialize(System.IO.Stream s)
        {
            return ((ReferredDocumentType3Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ReferredDocumentType3Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ReferredDocumentType3Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ReferredDocumentType3Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ReferredDocumentType3Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ReferredDocumentType3Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ReferredDocumentType3Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ReferredDocumentType3Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum DocumentType6Code
    {

        /// <remarks/>
        MSIN,

        /// <remarks/>
        CNFA,

        /// <remarks/>
        DNFA,

        /// <remarks/>
        CINV,

        /// <remarks/>
        CREN,

        /// <remarks/>
        DEBN,

        /// <remarks/>
        HIRI,

        /// <remarks/>
        SBIN,

        /// <remarks/>
        CMCN,

        /// <remarks/>
        SOAC,

        /// <remarks/>
        DISP,

        /// <remarks/>
        BOLD,

        /// <remarks/>
        VCHR,

        /// <remarks/>
        AROI,

        /// <remarks/>
        TSUT,

        /// <remarks/>
        PUOR,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class ReferredDocumentType4
    {

        #region Private fields
        private ReferredDocumentType3Choice _cdOrPrtry;

        private string _issr;

        private static XmlSerializer serializer;
        #endregion

        public ReferredDocumentType3Choice CdOrPrtry
        {
            get
            {
                return this._cdOrPrtry;
            }
            set
            {
                this._cdOrPrtry = value;
            }
        }

        public string Issr
        {
            get
            {
                return this._issr;
            }
            set
            {
                this._issr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(ReferredDocumentType4));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether CdOrPrtry should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdOrPrtry()
        {
            return (_cdOrPrtry != null);
        }

        /// <summary>
        /// Test whether Issr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIssr()
        {
            return !string.IsNullOrEmpty(Issr);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current ReferredDocumentType4 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an ReferredDocumentType4 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ReferredDocumentType4 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ReferredDocumentType4 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ReferredDocumentType4);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ReferredDocumentType4 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ReferredDocumentType4 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((ReferredDocumentType4)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ReferredDocumentType4 Deserialize(System.IO.Stream s)
        {
            return ((ReferredDocumentType4)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ReferredDocumentType4 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ReferredDocumentType4 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ReferredDocumentType4 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ReferredDocumentType4 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ReferredDocumentType4);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ReferredDocumentType4 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ReferredDocumentType4 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class ReferredDocumentInformation7
    {

        #region Private fields
        private bool _shouldSerializeRltdDt;

        private ReferredDocumentType4 _tp;

        private string _nb;

        private System.DateTime _rltdDt;

        private List<DocumentLineInformation1> _lineDtls;

        private static XmlSerializer serializer;
        #endregion

        public ReferredDocumentType4 Tp
        {
            get
            {
                return this._tp;
            }
            set
            {
                this._tp = value;
            }
        }

        public string Nb
        {
            get
            {
                return this._nb;
            }
            set
            {
                this._nb = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime RltdDt
        {
            get
            {
                return this._rltdDt;
            }
            set
            {
                this._rltdDt = value;
                _shouldSerializeRltdDt = true;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("LineDtls")]
        public List<DocumentLineInformation1> LineDtls
        {
            get
            {
                return this._lineDtls;
            }
            set
            {
                this._lineDtls = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(ReferredDocumentInformation7));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether LineDtls should be serialized
        /// </summary>
        public virtual bool ShouldSerializeLineDtls()
        {
            return LineDtls != null && LineDtls.Count > 0;
        }

        /// <summary>
        /// Test whether RltdDt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRltdDt()
        {
            if (_shouldSerializeRltdDt)
            {
                return true;
            }
            return (_rltdDt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether Tp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTp()
        {
            return (_tp != null);
        }

        /// <summary>
        /// Test whether Nb should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNb()
        {
            return !string.IsNullOrEmpty(Nb);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current ReferredDocumentInformation7 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an ReferredDocumentInformation7 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ReferredDocumentInformation7 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ReferredDocumentInformation7 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ReferredDocumentInformation7);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ReferredDocumentInformation7 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ReferredDocumentInformation7 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((ReferredDocumentInformation7)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ReferredDocumentInformation7 Deserialize(System.IO.Stream s)
        {
            return ((ReferredDocumentInformation7)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ReferredDocumentInformation7 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ReferredDocumentInformation7 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ReferredDocumentInformation7 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ReferredDocumentInformation7 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ReferredDocumentInformation7);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ReferredDocumentInformation7 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ReferredDocumentInformation7 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class StructuredRemittanceInformation15
    {

        #region Private fields
        private List<ReferredDocumentInformation7> _rfrdDocInf;

        private RemittanceAmount2 _rfrdDocAmt;

        private CreditorReferenceInformation2 _cdtrRefInf;

        private PartyIdentification125 _invcr;

        private PartyIdentification125 _invcee;

        private TaxInformation7 _taxRmt;

        private Garnishment2 _grnshmtRmt;

        private List<string> _addtlRmtInf;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("RfrdDocInf")]
        public List<ReferredDocumentInformation7> RfrdDocInf
        {
            get
            {
                return this._rfrdDocInf;
            }
            set
            {
                this._rfrdDocInf = value;
            }
        }

        public RemittanceAmount2 RfrdDocAmt
        {
            get
            {
                return this._rfrdDocAmt;
            }
            set
            {
                this._rfrdDocAmt = value;
            }
        }

        public CreditorReferenceInformation2 CdtrRefInf
        {
            get
            {
                return this._cdtrRefInf;
            }
            set
            {
                this._cdtrRefInf = value;
            }
        }

        public PartyIdentification125 Invcr
        {
            get
            {
                return this._invcr;
            }
            set
            {
                this._invcr = value;
            }
        }

        public PartyIdentification125 Invcee
        {
            get
            {
                return this._invcee;
            }
            set
            {
                this._invcee = value;
            }
        }

        public TaxInformation7 TaxRmt
        {
            get
            {
                return this._taxRmt;
            }
            set
            {
                this._taxRmt = value;
            }
        }

        public Garnishment2 GrnshmtRmt
        {
            get
            {
                return this._grnshmtRmt;
            }
            set
            {
                this._grnshmtRmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("AddtlRmtInf")]
        public List<string> AddtlRmtInf
        {
            get
            {
                return this._addtlRmtInf;
            }
            set
            {
                this._addtlRmtInf = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(StructuredRemittanceInformation15));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether RfrdDocInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRfrdDocInf()
        {
            return RfrdDocInf != null && RfrdDocInf.Count > 0;
        }

        /// <summary>
        /// Test whether AddtlRmtInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAddtlRmtInf()
        {
            return AddtlRmtInf != null && AddtlRmtInf.Count > 0;
        }

        /// <summary>
        /// Test whether RfrdDocAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRfrdDocAmt()
        {
            return (_rfrdDocAmt != null);
        }

        /// <summary>
        /// Test whether CdtrRefInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtrRefInf()
        {
            return (_cdtrRefInf != null);
        }

        /// <summary>
        /// Test whether Invcr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInvcr()
        {
            return (_invcr != null);
        }

        /// <summary>
        /// Test whether Invcee should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInvcee()
        {
            return (_invcee != null);
        }

        /// <summary>
        /// Test whether TaxRmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTaxRmt()
        {
            return (_taxRmt != null);
        }

        /// <summary>
        /// Test whether GrnshmtRmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeGrnshmtRmt()
        {
            return (_grnshmtRmt != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current StructuredRemittanceInformation15 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an StructuredRemittanceInformation15 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output StructuredRemittanceInformation15 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out StructuredRemittanceInformation15 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(StructuredRemittanceInformation15);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out StructuredRemittanceInformation15 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static StructuredRemittanceInformation15 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((StructuredRemittanceInformation15)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static StructuredRemittanceInformation15 Deserialize(System.IO.Stream s)
        {
            return ((StructuredRemittanceInformation15)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current StructuredRemittanceInformation15 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an StructuredRemittanceInformation15 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output StructuredRemittanceInformation15 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out StructuredRemittanceInformation15 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(StructuredRemittanceInformation15);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out StructuredRemittanceInformation15 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static StructuredRemittanceInformation15 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class RemittanceInformation15
    {

        #region Private fields
        private List<string> _ustrd;

        private List<StructuredRemittanceInformation15> _strd;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Ustrd")]
        public List<string> Ustrd
        {
            get
            {
                return this._ustrd;
            }
            set
            {
                this._ustrd = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Strd")]
        public List<StructuredRemittanceInformation15> Strd
        {
            get
            {
                return this._strd;
            }
            set
            {
                this._strd = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(RemittanceInformation15));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Ustrd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeUstrd()
        {
            return Ustrd != null && Ustrd.Count > 0;
        }

        /// <summary>
        /// Test whether Strd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeStrd()
        {
            return Strd != null && Strd.Count > 0;
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current RemittanceInformation15 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an RemittanceInformation15 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output RemittanceInformation15 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out RemittanceInformation15 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RemittanceInformation15);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out RemittanceInformation15 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static RemittanceInformation15 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((RemittanceInformation15)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static RemittanceInformation15 Deserialize(System.IO.Stream s)
        {
            return ((RemittanceInformation15)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current RemittanceInformation15 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an RemittanceInformation15 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output RemittanceInformation15 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out RemittanceInformation15 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RemittanceInformation15);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out RemittanceInformation15 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static RemittanceInformation15 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class NameAndAddress10
    {

        #region Private fields
        private string _nm;

        private PostalAddress6 _adr;

        private static XmlSerializer serializer;
        #endregion

        public string Nm
        {
            get
            {
                return this._nm;
            }
            set
            {
                this._nm = value;
            }
        }

        public PostalAddress6 Adr
        {
            get
            {
                return this._adr;
            }
            set
            {
                this._adr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(NameAndAddress10));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Adr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAdr()
        {
            return (_adr != null);
        }

        /// <summary>
        /// Test whether Nm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNm()
        {
            return !string.IsNullOrEmpty(Nm);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current NameAndAddress10 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an NameAndAddress10 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output NameAndAddress10 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out NameAndAddress10 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(NameAndAddress10);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out NameAndAddress10 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static NameAndAddress10 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((NameAndAddress10)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static NameAndAddress10 Deserialize(System.IO.Stream s)
        {
            return ((NameAndAddress10)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current NameAndAddress10 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an NameAndAddress10 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output NameAndAddress10 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out NameAndAddress10 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(NameAndAddress10);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out NameAndAddress10 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static NameAndAddress10 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class RemittanceLocationDetails1
    {

        #region Private fields
        private bool _shouldSerializeMtd;

        private RemittanceLocationMethod2Code _mtd;

        private string _elctrncAdr;

        private NameAndAddress10 _pstlAdr;

        private static XmlSerializer serializer;
        #endregion

        public RemittanceLocationMethod2Code Mtd
        {
            get
            {
                return this._mtd;
            }
            set
            {
                this._mtd = value;
                _shouldSerializeMtd = true;
            }
        }

        public string ElctrncAdr
        {
            get
            {
                return this._elctrncAdr;
            }
            set
            {
                this._elctrncAdr = value;
            }
        }

        public NameAndAddress10 PstlAdr
        {
            get
            {
                return this._pstlAdr;
            }
            set
            {
                this._pstlAdr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(RemittanceLocationDetails1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Mtd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeMtd()
        {
            if (_shouldSerializeMtd)
            {
                return true;
            }
            return (_mtd != default(RemittanceLocationMethod2Code));
        }

        /// <summary>
        /// Test whether PstlAdr should be serialized
        /// </summary>
        public virtual bool ShouldSerializePstlAdr()
        {
            return (_pstlAdr != null);
        }

        /// <summary>
        /// Test whether ElctrncAdr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeElctrncAdr()
        {
            return !string.IsNullOrEmpty(ElctrncAdr);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current RemittanceLocationDetails1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an RemittanceLocationDetails1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output RemittanceLocationDetails1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out RemittanceLocationDetails1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RemittanceLocationDetails1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out RemittanceLocationDetails1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static RemittanceLocationDetails1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((RemittanceLocationDetails1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static RemittanceLocationDetails1 Deserialize(System.IO.Stream s)
        {
            return ((RemittanceLocationDetails1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current RemittanceLocationDetails1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an RemittanceLocationDetails1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output RemittanceLocationDetails1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out RemittanceLocationDetails1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RemittanceLocationDetails1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out RemittanceLocationDetails1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static RemittanceLocationDetails1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum RemittanceLocationMethod2Code
    {

        /// <remarks/>
        FAXI,

        /// <remarks/>
        EDIC,

        /// <remarks/>
        URID,

        /// <remarks/>
        EMAL,

        /// <remarks/>
        POST,

        /// <remarks/>
        SMSM,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class RemittanceLocation4
    {

        #region Private fields
        private string _rmtId;

        private List<RemittanceLocationDetails1> _rmtLctnDtls;

        private static XmlSerializer serializer;
        #endregion

        public string RmtId
        {
            get
            {
                return this._rmtId;
            }
            set
            {
                this._rmtId = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("RmtLctnDtls")]
        public List<RemittanceLocationDetails1> RmtLctnDtls
        {
            get
            {
                return this._rmtLctnDtls;
            }
            set
            {
                this._rmtLctnDtls = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(RemittanceLocation4));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether RmtLctnDtls should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRmtLctnDtls()
        {
            return RmtLctnDtls != null && RmtLctnDtls.Count > 0;
        }

        /// <summary>
        /// Test whether RmtId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRmtId()
        {
            return !string.IsNullOrEmpty(RmtId);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current RemittanceLocation4 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an RemittanceLocation4 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output RemittanceLocation4 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out RemittanceLocation4 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RemittanceLocation4);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out RemittanceLocation4 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static RemittanceLocation4 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((RemittanceLocation4)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static RemittanceLocation4 Deserialize(System.IO.Stream s)
        {
            return ((RemittanceLocation4)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current RemittanceLocation4 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an RemittanceLocation4 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output RemittanceLocation4 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out RemittanceLocation4 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RemittanceLocation4);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out RemittanceLocation4 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static RemittanceLocation4 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class TaxInformation6
    {

        #region Private fields
        private bool _shouldSerializeSeqNb;

        private bool _shouldSerializeDt;

        private TaxParty1 _cdtr;

        private TaxParty2 _dbtr;

        private string _admstnZn;

        private string _refNb;

        private string _mtd;

        private ActiveOrHistoricCurrencyAndAmount _ttlTaxblBaseAmt;

        private ActiveOrHistoricCurrencyAndAmount _ttlTaxAmt;

        private System.DateTime _dt;

        private decimal _seqNb;

        private List<TaxRecord2> _rcrd;

        private static XmlSerializer serializer;
        #endregion

        public TaxParty1 Cdtr
        {
            get
            {
                return this._cdtr;
            }
            set
            {
                this._cdtr = value;
            }
        }

        public TaxParty2 Dbtr
        {
            get
            {
                return this._dbtr;
            }
            set
            {
                this._dbtr = value;
            }
        }

        public string AdmstnZn
        {
            get
            {
                return this._admstnZn;
            }
            set
            {
                this._admstnZn = value;
            }
        }

        public string RefNb
        {
            get
            {
                return this._refNb;
            }
            set
            {
                this._refNb = value;
            }
        }

        public string Mtd
        {
            get
            {
                return this._mtd;
            }
            set
            {
                this._mtd = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount TtlTaxblBaseAmt
        {
            get
            {
                return this._ttlTaxblBaseAmt;
            }
            set
            {
                this._ttlTaxblBaseAmt = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount TtlTaxAmt
        {
            get
            {
                return this._ttlTaxAmt;
            }
            set
            {
                this._ttlTaxAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime Dt
        {
            get
            {
                return this._dt;
            }
            set
            {
                this._dt = value;
                _shouldSerializeDt = true;
            }
        }

        public decimal SeqNb
        {
            get
            {
                return this._seqNb;
            }
            set
            {
                this._seqNb = value;
                _shouldSerializeSeqNb = true;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Rcrd")]
        public List<TaxRecord2> Rcrd
        {
            get
            {
                return this._rcrd;
            }
            set
            {
                this._rcrd = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(TaxInformation6));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Rcrd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRcrd()
        {
            return Rcrd != null && Rcrd.Count > 0;
        }

        /// <summary>
        /// Test whether Dt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDt()
        {
            if (_shouldSerializeDt)
            {
                return true;
            }
            return (_dt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether SeqNb should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSeqNb()
        {
            if (_shouldSerializeSeqNb)
            {
                return true;
            }
            return (_seqNb != default(decimal));
        }

        /// <summary>
        /// Test whether Cdtr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtr()
        {
            return (_cdtr != null);
        }

        /// <summary>
        /// Test whether Dbtr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDbtr()
        {
            return (_dbtr != null);
        }

        /// <summary>
        /// Test whether TtlTaxblBaseAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTtlTaxblBaseAmt()
        {
            return (_ttlTaxblBaseAmt != null);
        }

        /// <summary>
        /// Test whether TtlTaxAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTtlTaxAmt()
        {
            return (_ttlTaxAmt != null);
        }

        /// <summary>
        /// Test whether AdmstnZn should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAdmstnZn()
        {
            return !string.IsNullOrEmpty(AdmstnZn);
        }

        /// <summary>
        /// Test whether RefNb should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRefNb()
        {
            return !string.IsNullOrEmpty(RefNb);
        }

        /// <summary>
        /// Test whether Mtd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeMtd()
        {
            return !string.IsNullOrEmpty(Mtd);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current TaxInformation6 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an TaxInformation6 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output TaxInformation6 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out TaxInformation6 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxInformation6);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out TaxInformation6 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static TaxInformation6 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((TaxInformation6)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static TaxInformation6 Deserialize(System.IO.Stream s)
        {
            return ((TaxInformation6)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current TaxInformation6 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an TaxInformation6 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output TaxInformation6 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out TaxInformation6 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(TaxInformation6);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out TaxInformation6 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static TaxInformation6 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class StructuredRegulatoryReporting3
    {

        #region Private fields
        private bool _shouldSerializeDt;

        private string _tp;

        private System.DateTime _dt;

        private string _ctry;

        private string _cd;

        private ActiveOrHistoricCurrencyAndAmount _amt;

        private List<string> _inf;

        private static XmlSerializer serializer;
        #endregion

        public string Tp
        {
            get
            {
                return this._tp;
            }
            set
            {
                this._tp = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime Dt
        {
            get
            {
                return this._dt;
            }
            set
            {
                this._dt = value;
                _shouldSerializeDt = true;
            }
        }

        public string Ctry
        {
            get
            {
                return this._ctry;
            }
            set
            {
                this._ctry = value;
            }
        }

        public string Cd
        {
            get
            {
                return this._cd;
            }
            set
            {
                this._cd = value;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount Amt
        {
            get
            {
                return this._amt;
            }
            set
            {
                this._amt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Inf")]
        public List<string> Inf
        {
            get
            {
                return this._inf;
            }
            set
            {
                this._inf = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(StructuredRegulatoryReporting3));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Inf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInf()
        {
            return Inf != null && Inf.Count > 0;
        }

        /// <summary>
        /// Test whether Dt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDt()
        {
            if (_shouldSerializeDt)
            {
                return true;
            }
            return (_dt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether Amt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAmt()
        {
            return (_amt != null);
        }

        /// <summary>
        /// Test whether Tp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTp()
        {
            return !string.IsNullOrEmpty(Tp);
        }

        /// <summary>
        /// Test whether Ctry should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtry()
        {
            return !string.IsNullOrEmpty(Ctry);
        }

        /// <summary>
        /// Test whether Cd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCd()
        {
            return !string.IsNullOrEmpty(Cd);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current StructuredRegulatoryReporting3 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an StructuredRegulatoryReporting3 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output StructuredRegulatoryReporting3 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out StructuredRegulatoryReporting3 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(StructuredRegulatoryReporting3);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out StructuredRegulatoryReporting3 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static StructuredRegulatoryReporting3 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((StructuredRegulatoryReporting3)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static StructuredRegulatoryReporting3 Deserialize(System.IO.Stream s)
        {
            return ((StructuredRegulatoryReporting3)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current StructuredRegulatoryReporting3 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an StructuredRegulatoryReporting3 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output StructuredRegulatoryReporting3 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out StructuredRegulatoryReporting3 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(StructuredRegulatoryReporting3);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out StructuredRegulatoryReporting3 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static StructuredRegulatoryReporting3 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class RegulatoryAuthority2
    {

        #region Private fields
        private string _nm;

        private string _ctry;

        private static XmlSerializer serializer;
        #endregion

        public string Nm
        {
            get
            {
                return this._nm;
            }
            set
            {
                this._nm = value;
            }
        }

        public string Ctry
        {
            get
            {
                return this._ctry;
            }
            set
            {
                this._ctry = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(RegulatoryAuthority2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Nm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNm()
        {
            return !string.IsNullOrEmpty(Nm);
        }

        /// <summary>
        /// Test whether Ctry should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtry()
        {
            return !string.IsNullOrEmpty(Ctry);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current RegulatoryAuthority2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an RegulatoryAuthority2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output RegulatoryAuthority2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out RegulatoryAuthority2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RegulatoryAuthority2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out RegulatoryAuthority2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static RegulatoryAuthority2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((RegulatoryAuthority2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static RegulatoryAuthority2 Deserialize(System.IO.Stream s)
        {
            return ((RegulatoryAuthority2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current RegulatoryAuthority2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an RegulatoryAuthority2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output RegulatoryAuthority2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out RegulatoryAuthority2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RegulatoryAuthority2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out RegulatoryAuthority2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static RegulatoryAuthority2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class RegulatoryReporting3
    {

        #region Private fields
        private bool _shouldSerializeDbtCdtRptgInd;

        private RegulatoryReportingType1Code _dbtCdtRptgInd;

        private RegulatoryAuthority2 _authrty;

        private List<StructuredRegulatoryReporting3> _dtls;

        private static XmlSerializer serializer;
        #endregion

        public RegulatoryReportingType1Code DbtCdtRptgInd
        {
            get
            {
                return this._dbtCdtRptgInd;
            }
            set
            {
                this._dbtCdtRptgInd = value;
                _shouldSerializeDbtCdtRptgInd = true;
            }
        }

        public RegulatoryAuthority2 Authrty
        {
            get
            {
                return this._authrty;
            }
            set
            {
                this._authrty = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("Dtls")]
        public List<StructuredRegulatoryReporting3> Dtls
        {
            get
            {
                return this._dtls;
            }
            set
            {
                this._dtls = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(RegulatoryReporting3));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Dtls should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDtls()
        {
            return Dtls != null && Dtls.Count > 0;
        }

        /// <summary>
        /// Test whether DbtCdtRptgInd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDbtCdtRptgInd()
        {
            if (_shouldSerializeDbtCdtRptgInd)
            {
                return true;
            }
            return (_dbtCdtRptgInd != default(RegulatoryReportingType1Code));
        }

        /// <summary>
        /// Test whether Authrty should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAuthrty()
        {
            return (_authrty != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current RegulatoryReporting3 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an RegulatoryReporting3 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output RegulatoryReporting3 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out RegulatoryReporting3 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RegulatoryReporting3);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out RegulatoryReporting3 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static RegulatoryReporting3 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((RegulatoryReporting3)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static RegulatoryReporting3 Deserialize(System.IO.Stream s)
        {
            return ((RegulatoryReporting3)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current RegulatoryReporting3 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an RegulatoryReporting3 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output RegulatoryReporting3 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out RegulatoryReporting3 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(RegulatoryReporting3);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out RegulatoryReporting3 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static RegulatoryReporting3 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum RegulatoryReportingType1Code
    {

        /// <remarks/>
        CRED,

        /// <remarks/>
        DEBT,

        /// <remarks/>
        BOTH,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class Purpose2Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType10 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType10 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(Purpose2Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType10));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current Purpose2Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an Purpose2Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output Purpose2Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out Purpose2Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Purpose2Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out Purpose2Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static Purpose2Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((Purpose2Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static Purpose2Choice Deserialize(System.IO.Stream s)
        {
            return ((Purpose2Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current Purpose2Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an Purpose2Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Purpose2Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Purpose2Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Purpose2Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Purpose2Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Purpose2Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType10
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class InstructionForNextAgent1
    {

        #region Private fields
        private bool _shouldSerializeCd;

        private Instruction4Code _cd;

        private string _instrInf;

        private static XmlSerializer serializer;
        #endregion

        public Instruction4Code Cd
        {
            get
            {
                return this._cd;
            }
            set
            {
                this._cd = value;
                _shouldSerializeCd = true;
            }
        }

        public string InstrInf
        {
            get
            {
                return this._instrInf;
            }
            set
            {
                this._instrInf = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(InstructionForNextAgent1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Cd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCd()
        {
            if (_shouldSerializeCd)
            {
                return true;
            }
            return (_cd != default(Instruction4Code));
        }

        /// <summary>
        /// Test whether InstrInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstrInf()
        {
            return !string.IsNullOrEmpty(InstrInf);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current InstructionForNextAgent1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an InstructionForNextAgent1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output InstructionForNextAgent1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out InstructionForNextAgent1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(InstructionForNextAgent1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out InstructionForNextAgent1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static InstructionForNextAgent1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((InstructionForNextAgent1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static InstructionForNextAgent1 Deserialize(System.IO.Stream s)
        {
            return ((InstructionForNextAgent1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current InstructionForNextAgent1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an InstructionForNextAgent1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output InstructionForNextAgent1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out InstructionForNextAgent1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(InstructionForNextAgent1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out InstructionForNextAgent1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static InstructionForNextAgent1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum Instruction4Code
    {

        /// <remarks/>
        PHOA,

        /// <remarks/>
        TELA,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class InstructionForCreditorAgent1
    {

        #region Private fields
        private bool _shouldSerializeCd;

        private Instruction3Code _cd;

        private string _instrInf;

        private static XmlSerializer serializer;
        #endregion

        public Instruction3Code Cd
        {
            get
            {
                return this._cd;
            }
            set
            {
                this._cd = value;
                _shouldSerializeCd = true;
            }
        }

        public string InstrInf
        {
            get
            {
                return this._instrInf;
            }
            set
            {
                this._instrInf = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(InstructionForCreditorAgent1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Cd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCd()
        {
            if (_shouldSerializeCd)
            {
                return true;
            }
            return (_cd != default(Instruction3Code));
        }

        /// <summary>
        /// Test whether InstrInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstrInf()
        {
            return !string.IsNullOrEmpty(InstrInf);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current InstructionForCreditorAgent1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an InstructionForCreditorAgent1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output InstructionForCreditorAgent1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out InstructionForCreditorAgent1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(InstructionForCreditorAgent1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out InstructionForCreditorAgent1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static InstructionForCreditorAgent1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((InstructionForCreditorAgent1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static InstructionForCreditorAgent1 Deserialize(System.IO.Stream s)
        {
            return ((InstructionForCreditorAgent1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current InstructionForCreditorAgent1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an InstructionForCreditorAgent1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output InstructionForCreditorAgent1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out InstructionForCreditorAgent1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(InstructionForCreditorAgent1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out InstructionForCreditorAgent1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static InstructionForCreditorAgent1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum Instruction3Code
    {

        /// <remarks/>
        CHQB,

        /// <remarks/>
        HOLD,

        /// <remarks/>
        PHOB,

        /// <remarks/>
        TELB,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class Charges2
    {

        #region Private fields
        private ActiveOrHistoricCurrencyAndAmount _amt;

        private BranchAndFinancialInstitutionIdentification5 _agt;

        private static XmlSerializer serializer;
        #endregion

        public ActiveOrHistoricCurrencyAndAmount Amt
        {
            get
            {
                return this._amt;
            }
            set
            {
                this._amt = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 Agt
        {
            get
            {
                return this._agt;
            }
            set
            {
                this._agt = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(Charges2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Amt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAmt()
        {
            return (_amt != null);
        }

        /// <summary>
        /// Test whether Agt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAgt()
        {
            return (_agt != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current Charges2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an Charges2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output Charges2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out Charges2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Charges2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out Charges2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static Charges2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((Charges2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static Charges2 Deserialize(System.IO.Stream s)
        {
            return ((Charges2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current Charges2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an Charges2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output Charges2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out Charges2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(Charges2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out Charges2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static Charges2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class BranchAndFinancialInstitutionIdentification5
    {

        #region Private fields
        private FinancialInstitutionIdentification8 _finInstnId;

        private BranchData2 _brnchId;

        private static XmlSerializer serializer;
        #endregion

        public FinancialInstitutionIdentification8 FinInstnId
        {
            get
            {
                return this._finInstnId;
            }
            set
            {
                this._finInstnId = value;
            }
        }

        public BranchData2 BrnchId
        {
            get
            {
                return this._brnchId;
            }
            set
            {
                this._brnchId = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(BranchAndFinancialInstitutionIdentification5));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether FinInstnId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeFinInstnId()
        {
            return (_finInstnId != null);
        }

        /// <summary>
        /// Test whether BrnchId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeBrnchId()
        {
            return (_brnchId != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current BranchAndFinancialInstitutionIdentification5 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an BranchAndFinancialInstitutionIdentification5 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output BranchAndFinancialInstitutionIdentification5 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out BranchAndFinancialInstitutionIdentification5 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(BranchAndFinancialInstitutionIdentification5);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out BranchAndFinancialInstitutionIdentification5 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static BranchAndFinancialInstitutionIdentification5 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((BranchAndFinancialInstitutionIdentification5)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static BranchAndFinancialInstitutionIdentification5 Deserialize(System.IO.Stream s)
        {
            return ((BranchAndFinancialInstitutionIdentification5)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current BranchAndFinancialInstitutionIdentification5 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an BranchAndFinancialInstitutionIdentification5 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output BranchAndFinancialInstitutionIdentification5 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out BranchAndFinancialInstitutionIdentification5 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(BranchAndFinancialInstitutionIdentification5);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out BranchAndFinancialInstitutionIdentification5 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static BranchAndFinancialInstitutionIdentification5 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class FinancialInstitutionIdentification8
    {

        #region Private fields
        private string _bICFI;

        private ClearingSystemMemberIdentification2 _clrSysMmbId;

        private string _nm;

        private PostalAddress6 _pstlAdr;

        private GenericFinancialIdentification1 _othr;

        private static XmlSerializer serializer;
        #endregion

        public string BICFI
        {
            get
            {
                return this._bICFI;
            }
            set
            {
                this._bICFI = value;
            }
        }

        public ClearingSystemMemberIdentification2 ClrSysMmbId
        {
            get
            {
                return this._clrSysMmbId;
            }
            set
            {
                this._clrSysMmbId = value;
            }
        }

        public string Nm
        {
            get
            {
                return this._nm;
            }
            set
            {
                this._nm = value;
            }
        }

        public PostalAddress6 PstlAdr
        {
            get
            {
                return this._pstlAdr;
            }
            set
            {
                this._pstlAdr = value;
            }
        }

        public GenericFinancialIdentification1 Othr
        {
            get
            {
                return this._othr;
            }
            set
            {
                this._othr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(FinancialInstitutionIdentification8));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ClrSysMmbId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeClrSysMmbId()
        {
            return (_clrSysMmbId != null);
        }

        /// <summary>
        /// Test whether PstlAdr should be serialized
        /// </summary>
        public virtual bool ShouldSerializePstlAdr()
        {
            return (_pstlAdr != null);
        }

        /// <summary>
        /// Test whether Othr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeOthr()
        {
            return (_othr != null);
        }

        /// <summary>
        /// Test whether BICFI should be serialized
        /// </summary>
        public virtual bool ShouldSerializeBICFI()
        {
            return !string.IsNullOrEmpty(BICFI);
        }

        /// <summary>
        /// Test whether Nm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNm()
        {
            return !string.IsNullOrEmpty(Nm);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current FinancialInstitutionIdentification8 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an FinancialInstitutionIdentification8 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output FinancialInstitutionIdentification8 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out FinancialInstitutionIdentification8 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(FinancialInstitutionIdentification8);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out FinancialInstitutionIdentification8 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static FinancialInstitutionIdentification8 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((FinancialInstitutionIdentification8)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static FinancialInstitutionIdentification8 Deserialize(System.IO.Stream s)
        {
            return ((FinancialInstitutionIdentification8)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current FinancialInstitutionIdentification8 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an FinancialInstitutionIdentification8 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output FinancialInstitutionIdentification8 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out FinancialInstitutionIdentification8 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(FinancialInstitutionIdentification8);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out FinancialInstitutionIdentification8 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static FinancialInstitutionIdentification8 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class ClearingSystemMemberIdentification2
    {

        #region Private fields
        private ClearingSystemIdentification2Choice _clrSysId;

        private string _mmbId;

        private static XmlSerializer serializer;
        #endregion

        public ClearingSystemIdentification2Choice ClrSysId
        {
            get
            {
                return this._clrSysId;
            }
            set
            {
                this._clrSysId = value;
            }
        }

        public string MmbId
        {
            get
            {
                return this._mmbId;
            }
            set
            {
                this._mmbId = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(ClearingSystemMemberIdentification2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ClrSysId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeClrSysId()
        {
            return (_clrSysId != null);
        }

        /// <summary>
        /// Test whether MmbId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeMmbId()
        {
            return !string.IsNullOrEmpty(MmbId);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current ClearingSystemMemberIdentification2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an ClearingSystemMemberIdentification2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ClearingSystemMemberIdentification2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ClearingSystemMemberIdentification2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ClearingSystemMemberIdentification2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ClearingSystemMemberIdentification2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ClearingSystemMemberIdentification2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((ClearingSystemMemberIdentification2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ClearingSystemMemberIdentification2 Deserialize(System.IO.Stream s)
        {
            return ((ClearingSystemMemberIdentification2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ClearingSystemMemberIdentification2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ClearingSystemMemberIdentification2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ClearingSystemMemberIdentification2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ClearingSystemMemberIdentification2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ClearingSystemMemberIdentification2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ClearingSystemMemberIdentification2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ClearingSystemMemberIdentification2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class ClearingSystemIdentification2Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType3 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType3 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(ClearingSystemIdentification2Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType3));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current ClearingSystemIdentification2Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an ClearingSystemIdentification2Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ClearingSystemIdentification2Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ClearingSystemIdentification2Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ClearingSystemIdentification2Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ClearingSystemIdentification2Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ClearingSystemIdentification2Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((ClearingSystemIdentification2Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ClearingSystemIdentification2Choice Deserialize(System.IO.Stream s)
        {
            return ((ClearingSystemIdentification2Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ClearingSystemIdentification2Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ClearingSystemIdentification2Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ClearingSystemIdentification2Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ClearingSystemIdentification2Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ClearingSystemIdentification2Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ClearingSystemIdentification2Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ClearingSystemIdentification2Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType3
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class GenericFinancialIdentification1
    {

        #region Private fields
        private string _id;

        private FinancialIdentificationSchemeName1Choice _schmeNm;

        private string _issr;

        private static XmlSerializer serializer;
        #endregion

        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public FinancialIdentificationSchemeName1Choice SchmeNm
        {
            get
            {
                return this._schmeNm;
            }
            set
            {
                this._schmeNm = value;
            }
        }

        public string Issr
        {
            get
            {
                return this._issr;
            }
            set
            {
                this._issr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(GenericFinancialIdentification1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether SchmeNm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSchmeNm()
        {
            return (_schmeNm != null);
        }

        /// <summary>
        /// Test whether Id should be serialized
        /// </summary>
        public virtual bool ShouldSerializeId()
        {
            return !string.IsNullOrEmpty(Id);
        }

        /// <summary>
        /// Test whether Issr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIssr()
        {
            return !string.IsNullOrEmpty(Issr);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current GenericFinancialIdentification1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an GenericFinancialIdentification1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output GenericFinancialIdentification1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out GenericFinancialIdentification1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GenericFinancialIdentification1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out GenericFinancialIdentification1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static GenericFinancialIdentification1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((GenericFinancialIdentification1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static GenericFinancialIdentification1 Deserialize(System.IO.Stream s)
        {
            return ((GenericFinancialIdentification1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current GenericFinancialIdentification1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an GenericFinancialIdentification1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output GenericFinancialIdentification1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out GenericFinancialIdentification1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GenericFinancialIdentification1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out GenericFinancialIdentification1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static GenericFinancialIdentification1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class FinancialIdentificationSchemeName1Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType4 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType4 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(FinancialIdentificationSchemeName1Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType4));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current FinancialIdentificationSchemeName1Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an FinancialIdentificationSchemeName1Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output FinancialIdentificationSchemeName1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out FinancialIdentificationSchemeName1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(FinancialIdentificationSchemeName1Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out FinancialIdentificationSchemeName1Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static FinancialIdentificationSchemeName1Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((FinancialIdentificationSchemeName1Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static FinancialIdentificationSchemeName1Choice Deserialize(System.IO.Stream s)
        {
            return ((FinancialIdentificationSchemeName1Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current FinancialIdentificationSchemeName1Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an FinancialIdentificationSchemeName1Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output FinancialIdentificationSchemeName1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out FinancialIdentificationSchemeName1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(FinancialIdentificationSchemeName1Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out FinancialIdentificationSchemeName1Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static FinancialIdentificationSchemeName1Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType4
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class BranchData2
    {

        #region Private fields
        private string _id;

        private string _nm;

        private PostalAddress6 _pstlAdr;

        private static XmlSerializer serializer;
        #endregion

        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string Nm
        {
            get
            {
                return this._nm;
            }
            set
            {
                this._nm = value;
            }
        }

        public PostalAddress6 PstlAdr
        {
            get
            {
                return this._pstlAdr;
            }
            set
            {
                this._pstlAdr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(BranchData2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether PstlAdr should be serialized
        /// </summary>
        public virtual bool ShouldSerializePstlAdr()
        {
            return (_pstlAdr != null);
        }

        /// <summary>
        /// Test whether Id should be serialized
        /// </summary>
        public virtual bool ShouldSerializeId()
        {
            return !string.IsNullOrEmpty(Id);
        }

        /// <summary>
        /// Test whether Nm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNm()
        {
            return !string.IsNullOrEmpty(Nm);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current BranchData2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an BranchData2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output BranchData2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out BranchData2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(BranchData2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out BranchData2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static BranchData2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((BranchData2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static BranchData2 Deserialize(System.IO.Stream s)
        {
            return ((BranchData2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current BranchData2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an BranchData2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output BranchData2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out BranchData2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(BranchData2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out BranchData2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static BranchData2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class SettlementTimeRequest2
    {

        #region Private fields
        private bool _shouldSerializeRjctTm;

        private bool _shouldSerializeFrTm;

        private bool _shouldSerializeTillTm;

        private bool _shouldSerializeCLSTm;

        private System.DateTime _cLSTm;

        private System.DateTime _tillTm;

        private System.DateTime _frTm;

        private System.DateTime _rjctTm;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute(DataType = "time")]
        public System.DateTime CLSTm
        {
            get
            {
                return this._cLSTm;
            }
            set
            {
                this._cLSTm = value;
                _shouldSerializeCLSTm = true;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "time")]
        public System.DateTime TillTm
        {
            get
            {
                return this._tillTm;
            }
            set
            {
                this._tillTm = value;
                _shouldSerializeTillTm = true;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "time")]
        public System.DateTime FrTm
        {
            get
            {
                return this._frTm;
            }
            set
            {
                this._frTm = value;
                _shouldSerializeFrTm = true;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "time")]
        public System.DateTime RjctTm
        {
            get
            {
                return this._rjctTm;
            }
            set
            {
                this._rjctTm = value;
                _shouldSerializeRjctTm = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(SettlementTimeRequest2));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether CLSTm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCLSTm()
        {
            if (_shouldSerializeCLSTm)
            {
                return true;
            }
            return (_cLSTm != default(System.DateTime));
        }

        /// <summary>
        /// Test whether TillTm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTillTm()
        {
            if (_shouldSerializeTillTm)
            {
                return true;
            }
            return (_tillTm != default(System.DateTime));
        }

        /// <summary>
        /// Test whether FrTm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeFrTm()
        {
            if (_shouldSerializeFrTm)
            {
                return true;
            }
            return (_frTm != default(System.DateTime));
        }

        /// <summary>
        /// Test whether RjctTm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRjctTm()
        {
            if (_shouldSerializeRjctTm)
            {
                return true;
            }
            return (_rjctTm != default(System.DateTime));
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current SettlementTimeRequest2 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an SettlementTimeRequest2 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output SettlementTimeRequest2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out SettlementTimeRequest2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(SettlementTimeRequest2);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out SettlementTimeRequest2 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static SettlementTimeRequest2 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((SettlementTimeRequest2)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static SettlementTimeRequest2 Deserialize(System.IO.Stream s)
        {
            return ((SettlementTimeRequest2)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current SettlementTimeRequest2 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an SettlementTimeRequest2 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output SettlementTimeRequest2 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out SettlementTimeRequest2 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(SettlementTimeRequest2);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out SettlementTimeRequest2 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static SettlementTimeRequest2 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class SettlementDateTimeIndication1
    {

        #region Private fields
        private bool _shouldSerializeCdtDtTm;

        private bool _shouldSerializeDbtDtTm;

        private System.DateTime _dbtDtTm;

        private System.DateTime _cdtDtTm;

        private static XmlSerializer serializer;
        #endregion

        public System.DateTime DbtDtTm
        {
            get
            {
                return this._dbtDtTm;
            }
            set
            {
                this._dbtDtTm = value;
                _shouldSerializeDbtDtTm = true;
            }
        }

        public System.DateTime CdtDtTm
        {
            get
            {
                return this._cdtDtTm;
            }
            set
            {
                this._cdtDtTm = value;
                _shouldSerializeCdtDtTm = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(SettlementDateTimeIndication1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether DbtDtTm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDbtDtTm()
        {
            if (_shouldSerializeDbtDtTm)
            {
                return true;
            }
            return (_dbtDtTm != default(System.DateTime));
        }

        /// <summary>
        /// Test whether CdtDtTm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtDtTm()
        {
            if (_shouldSerializeCdtDtTm)
            {
                return true;
            }
            return (_cdtDtTm != default(System.DateTime));
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current SettlementDateTimeIndication1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an SettlementDateTimeIndication1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output SettlementDateTimeIndication1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out SettlementDateTimeIndication1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(SettlementDateTimeIndication1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out SettlementDateTimeIndication1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static SettlementDateTimeIndication1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((SettlementDateTimeIndication1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static SettlementDateTimeIndication1 Deserialize(System.IO.Stream s)
        {
            return ((SettlementDateTimeIndication1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current SettlementDateTimeIndication1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an SettlementDateTimeIndication1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output SettlementDateTimeIndication1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out SettlementDateTimeIndication1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(SettlementDateTimeIndication1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out SettlementDateTimeIndication1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static SettlementDateTimeIndication1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class PaymentIdentification3
    {

        #region Private fields
        private string _instrId;

        private string _endToEndId;

        private string _txId;

        private string _clrSysRef;

        private static XmlSerializer serializer;
        #endregion

        public string InstrId
        {
            get
            {
                return this._instrId;
            }
            set
            {
                this._instrId = value;
            }
        }

        public string EndToEndId
        {
            get
            {
                return this._endToEndId;
            }
            set
            {
                this._endToEndId = value;
            }
        }

        public string TxId
        {
            get
            {
                return this._txId;
            }
            set
            {
                this._txId = value;
            }
        }

        public string ClrSysRef
        {
            get
            {
                return this._clrSysRef;
            }
            set
            {
                this._clrSysRef = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(PaymentIdentification3));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether InstrId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstrId()
        {
            return !string.IsNullOrEmpty(InstrId);
        }

        /// <summary>
        /// Test whether EndToEndId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeEndToEndId()
        {
            return !string.IsNullOrEmpty(EndToEndId);
        }

        /// <summary>
        /// Test whether TxId should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTxId()
        {
            return !string.IsNullOrEmpty(TxId);
        }

        /// <summary>
        /// Test whether ClrSysRef should be serialized
        /// </summary>
        public virtual bool ShouldSerializeClrSysRef()
        {
            return !string.IsNullOrEmpty(ClrSysRef);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current PaymentIdentification3 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an PaymentIdentification3 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output PaymentIdentification3 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out PaymentIdentification3 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PaymentIdentification3);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out PaymentIdentification3 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static PaymentIdentification3 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((PaymentIdentification3)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static PaymentIdentification3 Deserialize(System.IO.Stream s)
        {
            return ((PaymentIdentification3)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current PaymentIdentification3 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an PaymentIdentification3 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PaymentIdentification3 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PaymentIdentification3 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PaymentIdentification3);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out PaymentIdentification3 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static PaymentIdentification3 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class CreditTransferTransaction30
    {

        #region Private fields
        private bool _shouldSerializeChrgBr;

        private bool _shouldSerializeSttlmPrty;

        private bool _shouldSerializeXchgRate;

        private bool _shouldSerializePoolgAdjstmntDt;

        private bool _shouldSerializeAccptncDtTm;

        private bool _shouldSerializeIntrBkSttlmDt;

        private PaymentIdentification3 _pmtId;

        private PaymentTypeInformation21 _pmtTpInf;

        private ActiveCurrencyAndAmount _intrBkSttlmAmt;

        private System.DateTime _intrBkSttlmDt;

        private Priority3Code _sttlmPrty;

        private SettlementDateTimeIndication1 _sttlmTmIndctn;

        private SettlementTimeRequest2 _sttlmTmReq;

        private System.DateTime _accptncDtTm;

        private System.DateTime _poolgAdjstmntDt;

        private ActiveOrHistoricCurrencyAndAmount _instdAmt;

        private decimal _xchgRate;

        private ChargeBearerType1Code _chrgBr;

        private List<Charges2> _chrgsInf;

        private BranchAndFinancialInstitutionIdentification5 _prvsInstgAgt1;

        private CashAccount24 _prvsInstgAgt1Acct;

        private BranchAndFinancialInstitutionIdentification5 _prvsInstgAgt2;

        private CashAccount24 _prvsInstgAgt2Acct;

        private BranchAndFinancialInstitutionIdentification5 _prvsInstgAgt3;

        private CashAccount24 _prvsInstgAgt3Acct;

        private BranchAndFinancialInstitutionIdentification5 _instgAgt;

        private BranchAndFinancialInstitutionIdentification5 _instdAgt;

        private BranchAndFinancialInstitutionIdentification5 _intrmyAgt1;

        private CashAccount24 _intrmyAgt1Acct;

        private BranchAndFinancialInstitutionIdentification5 _intrmyAgt2;

        private CashAccount24 _intrmyAgt2Acct;

        private BranchAndFinancialInstitutionIdentification5 _intrmyAgt3;

        private CashAccount24 _intrmyAgt3Acct;

        private PartyIdentification125 _ultmtDbtr;

        private PartyIdentification125 _initgPty;

        private PartyIdentification125 _dbtr;

        private CashAccount24 _dbtrAcct;

        private BranchAndFinancialInstitutionIdentification5 _dbtrAgt;

        private CashAccount24 _dbtrAgtAcct;

        private BranchAndFinancialInstitutionIdentification5 _cdtrAgt;

        private CashAccount24 _cdtrAgtAcct;

        private PartyIdentification125 _cdtr;

        private CashAccount24 _cdtrAcct;

        private PartyIdentification125 _ultmtCdtr;

        private List<InstructionForCreditorAgent1> _instrForCdtrAgt;

        private List<InstructionForNextAgent1> _instrForNxtAgt;

        private Purpose2Choice _purp;

        private List<RegulatoryReporting3> _rgltryRptg;

        private TaxInformation6 _tax;

        private List<RemittanceLocation4> _rltdRmtInf;

        private RemittanceInformation15 _rmtInf;

        private List<SupplementaryData1> _splmtryData;

        private static XmlSerializer serializer;
        #endregion

        public PaymentIdentification3 PmtId
        {
            get
            {
                return this._pmtId;
            }
            set
            {
                this._pmtId = value;
            }
        }

        public PaymentTypeInformation21 PmtTpInf
        {
            get
            {
                return this._pmtTpInf;
            }
            set
            {
                this._pmtTpInf = value;
            }
        }

        public ActiveCurrencyAndAmount IntrBkSttlmAmt
        {
            get
            {
                return this._intrBkSttlmAmt;
            }
            set
            {
                this._intrBkSttlmAmt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime IntrBkSttlmDt
        {
            get
            {
                return this._intrBkSttlmDt;
            }
            set
            {
                this._intrBkSttlmDt = value;
                _shouldSerializeIntrBkSttlmDt = true;
            }
        }

        public Priority3Code SttlmPrty
        {
            get
            {
                return this._sttlmPrty;
            }
            set
            {
                this._sttlmPrty = value;
                _shouldSerializeSttlmPrty = true;
            }
        }

        public SettlementDateTimeIndication1 SttlmTmIndctn
        {
            get
            {
                return this._sttlmTmIndctn;
            }
            set
            {
                this._sttlmTmIndctn = value;
            }
        }

        public SettlementTimeRequest2 SttlmTmReq
        {
            get
            {
                return this._sttlmTmReq;
            }
            set
            {
                this._sttlmTmReq = value;
            }
        }

        public System.DateTime AccptncDtTm
        {
            get
            {
                return this._accptncDtTm;
            }
            set
            {
                this._accptncDtTm = value;
                _shouldSerializeAccptncDtTm = true;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime PoolgAdjstmntDt
        {
            get
            {
                return this._poolgAdjstmntDt;
            }
            set
            {
                this._poolgAdjstmntDt = value;
                _shouldSerializePoolgAdjstmntDt = true;
            }
        }

        public ActiveOrHistoricCurrencyAndAmount InstdAmt
        {
            get
            {
                return this._instdAmt;
            }
            set
            {
                this._instdAmt = value;
            }
        }

        public decimal XchgRate
        {
            get
            {
                return this._xchgRate;
            }
            set
            {
                this._xchgRate = value;
                _shouldSerializeXchgRate = true;
            }
        }

        public ChargeBearerType1Code ChrgBr
        {
            get
            {
                return this._chrgBr;
            }
            set
            {
                this._chrgBr = value;
                _shouldSerializeChrgBr = true;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("ChrgsInf")]
        public List<Charges2> ChrgsInf
        {
            get
            {
                return this._chrgsInf;
            }
            set
            {
                this._chrgsInf = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 PrvsInstgAgt1
        {
            get
            {
                return this._prvsInstgAgt1;
            }
            set
            {
                this._prvsInstgAgt1 = value;
            }
        }

        public CashAccount24 PrvsInstgAgt1Acct
        {
            get
            {
                return this._prvsInstgAgt1Acct;
            }
            set
            {
                this._prvsInstgAgt1Acct = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 PrvsInstgAgt2
        {
            get
            {
                return this._prvsInstgAgt2;
            }
            set
            {
                this._prvsInstgAgt2 = value;
            }
        }

        public CashAccount24 PrvsInstgAgt2Acct
        {
            get
            {
                return this._prvsInstgAgt2Acct;
            }
            set
            {
                this._prvsInstgAgt2Acct = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 PrvsInstgAgt3
        {
            get
            {
                return this._prvsInstgAgt3;
            }
            set
            {
                this._prvsInstgAgt3 = value;
            }
        }

        public CashAccount24 PrvsInstgAgt3Acct
        {
            get
            {
                return this._prvsInstgAgt3Acct;
            }
            set
            {
                this._prvsInstgAgt3Acct = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 InstgAgt
        {
            get
            {
                return this._instgAgt;
            }
            set
            {
                this._instgAgt = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 InstdAgt
        {
            get
            {
                return this._instdAgt;
            }
            set
            {
                this._instdAgt = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 IntrmyAgt1
        {
            get
            {
                return this._intrmyAgt1;
            }
            set
            {
                this._intrmyAgt1 = value;
            }
        }

        public CashAccount24 IntrmyAgt1Acct
        {
            get
            {
                return this._intrmyAgt1Acct;
            }
            set
            {
                this._intrmyAgt1Acct = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 IntrmyAgt2
        {
            get
            {
                return this._intrmyAgt2;
            }
            set
            {
                this._intrmyAgt2 = value;
            }
        }

        public CashAccount24 IntrmyAgt2Acct
        {
            get
            {
                return this._intrmyAgt2Acct;
            }
            set
            {
                this._intrmyAgt2Acct = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 IntrmyAgt3
        {
            get
            {
                return this._intrmyAgt3;
            }
            set
            {
                this._intrmyAgt3 = value;
            }
        }

        public CashAccount24 IntrmyAgt3Acct
        {
            get
            {
                return this._intrmyAgt3Acct;
            }
            set
            {
                this._intrmyAgt3Acct = value;
            }
        }

        public PartyIdentification125 UltmtDbtr
        {
            get
            {
                return this._ultmtDbtr;
            }
            set
            {
                this._ultmtDbtr = value;
            }
        }

        public PartyIdentification125 InitgPty
        {
            get
            {
                return this._initgPty;
            }
            set
            {
                this._initgPty = value;
            }
        }

        public PartyIdentification125 Dbtr
        {
            get
            {
                return this._dbtr;
            }
            set
            {
                this._dbtr = value;
            }
        }

        public CashAccount24 DbtrAcct
        {
            get
            {
                return this._dbtrAcct;
            }
            set
            {
                this._dbtrAcct = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 DbtrAgt
        {
            get
            {
                return this._dbtrAgt;
            }
            set
            {
                this._dbtrAgt = value;
            }
        }

        public CashAccount24 DbtrAgtAcct
        {
            get
            {
                return this._dbtrAgtAcct;
            }
            set
            {
                this._dbtrAgtAcct = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 CdtrAgt
        {
            get
            {
                return this._cdtrAgt;
            }
            set
            {
                this._cdtrAgt = value;
            }
        }

        public CashAccount24 CdtrAgtAcct
        {
            get
            {
                return this._cdtrAgtAcct;
            }
            set
            {
                this._cdtrAgtAcct = value;
            }
        }

        public PartyIdentification125 Cdtr
        {
            get
            {
                return this._cdtr;
            }
            set
            {
                this._cdtr = value;
            }
        }

        public CashAccount24 CdtrAcct
        {
            get
            {
                return this._cdtrAcct;
            }
            set
            {
                this._cdtrAcct = value;
            }
        }

        public PartyIdentification125 UltmtCdtr
        {
            get
            {
                return this._ultmtCdtr;
            }
            set
            {
                this._ultmtCdtr = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("InstrForCdtrAgt")]
        public List<InstructionForCreditorAgent1> InstrForCdtrAgt
        {
            get
            {
                return this._instrForCdtrAgt;
            }
            set
            {
                this._instrForCdtrAgt = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("InstrForNxtAgt")]
        public List<InstructionForNextAgent1> InstrForNxtAgt
        {
            get
            {
                return this._instrForNxtAgt;
            }
            set
            {
                this._instrForNxtAgt = value;
            }
        }

        public Purpose2Choice Purp
        {
            get
            {
                return this._purp;
            }
            set
            {
                this._purp = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("RgltryRptg")]
        public List<RegulatoryReporting3> RgltryRptg
        {
            get
            {
                return this._rgltryRptg;
            }
            set
            {
                this._rgltryRptg = value;
            }
        }

        public TaxInformation6 Tax
        {
            get
            {
                return this._tax;
            }
            set
            {
                this._tax = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("RltdRmtInf")]
        public List<RemittanceLocation4> RltdRmtInf
        {
            get
            {
                return this._rltdRmtInf;
            }
            set
            {
                this._rltdRmtInf = value;
            }
        }

        public RemittanceInformation15 RmtInf
        {
            get
            {
                return this._rmtInf;
            }
            set
            {
                this._rmtInf = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("SplmtryData")]
        public List<SupplementaryData1> SplmtryData
        {
            get
            {
                return this._splmtryData;
            }
            set
            {
                this._splmtryData = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(CreditTransferTransaction30));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ChrgsInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeChrgsInf()
        {
            return ChrgsInf != null && ChrgsInf.Count > 0;
        }

        /// <summary>
        /// Test whether InstrForCdtrAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstrForCdtrAgt()
        {
            return InstrForCdtrAgt != null && InstrForCdtrAgt.Count > 0;
        }

        /// <summary>
        /// Test whether InstrForNxtAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstrForNxtAgt()
        {
            return InstrForNxtAgt != null && InstrForNxtAgt.Count > 0;
        }

        /// <summary>
        /// Test whether RgltryRptg should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRgltryRptg()
        {
            return RgltryRptg != null && RgltryRptg.Count > 0;
        }

        /// <summary>
        /// Test whether RltdRmtInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRltdRmtInf()
        {
            return RltdRmtInf != null && RltdRmtInf.Count > 0;
        }

        /// <summary>
        /// Test whether SplmtryData should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSplmtryData()
        {
            return SplmtryData != null && SplmtryData.Count > 0;
        }

        /// <summary>
        /// Test whether IntrBkSttlmDt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIntrBkSttlmDt()
        {
            if (_shouldSerializeIntrBkSttlmDt)
            {
                return true;
            }
            return (_intrBkSttlmDt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether AccptncDtTm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeAccptncDtTm()
        {
            if (_shouldSerializeAccptncDtTm)
            {
                return true;
            }
            return (_accptncDtTm != default(System.DateTime));
        }

        /// <summary>
        /// Test whether PoolgAdjstmntDt should be serialized
        /// </summary>
        public virtual bool ShouldSerializePoolgAdjstmntDt()
        {
            if (_shouldSerializePoolgAdjstmntDt)
            {
                return true;
            }
            return (_poolgAdjstmntDt != default(System.DateTime));
        }

        /// <summary>
        /// Test whether XchgRate should be serialized
        /// </summary>
        public virtual bool ShouldSerializeXchgRate()
        {
            if (_shouldSerializeXchgRate)
            {
                return true;
            }
            return (_xchgRate != default(decimal));
        }

        /// <summary>
        /// Test whether SttlmPrty should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSttlmPrty()
        {
            if (_shouldSerializeSttlmPrty)
            {
                return true;
            }
            return (_sttlmPrty != default(Priority3Code));
        }

        /// <summary>
        /// Test whether ChrgBr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeChrgBr()
        {
            if (_shouldSerializeChrgBr)
            {
                return true;
            }
            return (_chrgBr != default(ChargeBearerType1Code));
        }

        /// <summary>
        /// Test whether PmtId should be serialized
        /// </summary>
        public virtual bool ShouldSerializePmtId()
        {
            return (_pmtId != null);
        }

        /// <summary>
        /// Test whether PmtTpInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializePmtTpInf()
        {
            return (_pmtTpInf != null);
        }

        /// <summary>
        /// Test whether IntrBkSttlmAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIntrBkSttlmAmt()
        {
            return (_intrBkSttlmAmt != null);
        }

        /// <summary>
        /// Test whether SttlmTmIndctn should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSttlmTmIndctn()
        {
            return (_sttlmTmIndctn != null);
        }

        /// <summary>
        /// Test whether SttlmTmReq should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSttlmTmReq()
        {
            return (_sttlmTmReq != null);
        }

        /// <summary>
        /// Test whether InstdAmt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstdAmt()
        {
            return (_instdAmt != null);
        }

        /// <summary>
        /// Test whether PrvsInstgAgt1 should be serialized
        /// </summary>
        public virtual bool ShouldSerializePrvsInstgAgt1()
        {
            return (_prvsInstgAgt1 != null);
        }

        /// <summary>
        /// Test whether PrvsInstgAgt1Acct should be serialized
        /// </summary>
        public virtual bool ShouldSerializePrvsInstgAgt1Acct()
        {
            return (_prvsInstgAgt1Acct != null);
        }

        /// <summary>
        /// Test whether PrvsInstgAgt2 should be serialized
        /// </summary>
        public virtual bool ShouldSerializePrvsInstgAgt2()
        {
            return (_prvsInstgAgt2 != null);
        }

        /// <summary>
        /// Test whether PrvsInstgAgt2Acct should be serialized
        /// </summary>
        public virtual bool ShouldSerializePrvsInstgAgt2Acct()
        {
            return (_prvsInstgAgt2Acct != null);
        }

        /// <summary>
        /// Test whether PrvsInstgAgt3 should be serialized
        /// </summary>
        public virtual bool ShouldSerializePrvsInstgAgt3()
        {
            return (_prvsInstgAgt3 != null);
        }

        /// <summary>
        /// Test whether PrvsInstgAgt3Acct should be serialized
        /// </summary>
        public virtual bool ShouldSerializePrvsInstgAgt3Acct()
        {
            return (_prvsInstgAgt3Acct != null);
        }

        /// <summary>
        /// Test whether InstgAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstgAgt()
        {
            return (_instgAgt != null);
        }

        /// <summary>
        /// Test whether InstdAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstdAgt()
        {
            return (_instdAgt != null);
        }

        /// <summary>
        /// Test whether IntrmyAgt1 should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIntrmyAgt1()
        {
            return (_intrmyAgt1 != null);
        }

        /// <summary>
        /// Test whether IntrmyAgt1Acct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIntrmyAgt1Acct()
        {
            return (_intrmyAgt1Acct != null);
        }

        /// <summary>
        /// Test whether IntrmyAgt2 should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIntrmyAgt2()
        {
            return (_intrmyAgt2 != null);
        }

        /// <summary>
        /// Test whether IntrmyAgt2Acct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIntrmyAgt2Acct()
        {
            return (_intrmyAgt2Acct != null);
        }

        /// <summary>
        /// Test whether IntrmyAgt3 should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIntrmyAgt3()
        {
            return (_intrmyAgt3 != null);
        }

        /// <summary>
        /// Test whether IntrmyAgt3Acct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIntrmyAgt3Acct()
        {
            return (_intrmyAgt3Acct != null);
        }

        /// <summary>
        /// Test whether UltmtDbtr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeUltmtDbtr()
        {
            return (_ultmtDbtr != null);
        }

        /// <summary>
        /// Test whether InitgPty should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInitgPty()
        {
            return (_initgPty != null);
        }

        /// <summary>
        /// Test whether Dbtr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDbtr()
        {
            return (_dbtr != null);
        }

        /// <summary>
        /// Test whether DbtrAcct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDbtrAcct()
        {
            return (_dbtrAcct != null);
        }

        /// <summary>
        /// Test whether DbtrAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDbtrAgt()
        {
            return (_dbtrAgt != null);
        }

        /// <summary>
        /// Test whether DbtrAgtAcct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeDbtrAgtAcct()
        {
            return (_dbtrAgtAcct != null);
        }

        /// <summary>
        /// Test whether CdtrAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtrAgt()
        {
            return (_cdtrAgt != null);
        }

        /// <summary>
        /// Test whether CdtrAgtAcct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtrAgtAcct()
        {
            return (_cdtrAgtAcct != null);
        }

        /// <summary>
        /// Test whether Cdtr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtr()
        {
            return (_cdtr != null);
        }

        /// <summary>
        /// Test whether CdtrAcct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCdtrAcct()
        {
            return (_cdtrAcct != null);
        }

        /// <summary>
        /// Test whether UltmtCdtr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeUltmtCdtr()
        {
            return (_ultmtCdtr != null);
        }

        /// <summary>
        /// Test whether Purp should be serialized
        /// </summary>
        public virtual bool ShouldSerializePurp()
        {
            return (_purp != null);
        }

        /// <summary>
        /// Test whether Tax should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTax()
        {
            return (_tax != null);
        }

        /// <summary>
        /// Test whether RmtInf should be serialized
        /// </summary>
        public virtual bool ShouldSerializeRmtInf()
        {
            return (_rmtInf != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CreditTransferTransaction30 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an CreditTransferTransaction30 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CreditTransferTransaction30 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CreditTransferTransaction30 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CreditTransferTransaction30);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out CreditTransferTransaction30 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static CreditTransferTransaction30 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CreditTransferTransaction30)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CreditTransferTransaction30 Deserialize(System.IO.Stream s)
        {
            return ((CreditTransferTransaction30)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current CreditTransferTransaction30 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an CreditTransferTransaction30 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output CreditTransferTransaction30 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out CreditTransferTransaction30 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CreditTransferTransaction30);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out CreditTransferTransaction30 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static CreditTransferTransaction30 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class PaymentTypeInformation21
    {

        #region Private fields
        private bool _shouldSerializeClrChanl;

        private bool _shouldSerializeInstrPrty;

        private Priority2Code _instrPrty;

        private ClearingChannel2Code _clrChanl;

        private ServiceLevel8Choice _svcLvl;

        private LocalInstrument2Choice _lclInstrm;

        private CategoryPurpose1Choice _ctgyPurp;

        private static XmlSerializer serializer;
        #endregion

        public Priority2Code InstrPrty
        {
            get
            {
                return this._instrPrty;
            }
            set
            {
                this._instrPrty = value;
                _shouldSerializeInstrPrty = true;
            }
        }

        public ClearingChannel2Code ClrChanl
        {
            get
            {
                return this._clrChanl;
            }
            set
            {
                this._clrChanl = value;
                _shouldSerializeClrChanl = true;
            }
        }

        public ServiceLevel8Choice SvcLvl
        {
            get
            {
                return this._svcLvl;
            }
            set
            {
                this._svcLvl = value;
            }
        }

        public LocalInstrument2Choice LclInstrm
        {
            get
            {
                return this._lclInstrm;
            }
            set
            {
                this._lclInstrm = value;
            }
        }

        public CategoryPurpose1Choice CtgyPurp
        {
            get
            {
                return this._ctgyPurp;
            }
            set
            {
                this._ctgyPurp = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(PaymentTypeInformation21));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether InstrPrty should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstrPrty()
        {
            if (_shouldSerializeInstrPrty)
            {
                return true;
            }
            return (_instrPrty != default(Priority2Code));
        }

        /// <summary>
        /// Test whether ClrChanl should be serialized
        /// </summary>
        public virtual bool ShouldSerializeClrChanl()
        {
            if (_shouldSerializeClrChanl)
            {
                return true;
            }
            return (_clrChanl != default(ClearingChannel2Code));
        }

        /// <summary>
        /// Test whether SvcLvl should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSvcLvl()
        {
            return (_svcLvl != null);
        }

        /// <summary>
        /// Test whether LclInstrm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeLclInstrm()
        {
            return (_lclInstrm != null);
        }

        /// <summary>
        /// Test whether CtgyPurp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCtgyPurp()
        {
            return (_ctgyPurp != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current PaymentTypeInformation21 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an PaymentTypeInformation21 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output PaymentTypeInformation21 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out PaymentTypeInformation21 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PaymentTypeInformation21);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out PaymentTypeInformation21 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static PaymentTypeInformation21 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((PaymentTypeInformation21)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static PaymentTypeInformation21 Deserialize(System.IO.Stream s)
        {
            return ((PaymentTypeInformation21)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current PaymentTypeInformation21 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an PaymentTypeInformation21 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output PaymentTypeInformation21 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out PaymentTypeInformation21 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(PaymentTypeInformation21);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out PaymentTypeInformation21 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static PaymentTypeInformation21 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum Priority2Code
    {

        /// <remarks/>
        HIGH,

        /// <remarks/>
        NORM,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum ClearingChannel2Code
    {

        /// <remarks/>
        RTGS,

        /// <remarks/>
        RTNS,

        /// <remarks/>
        MPNS,

        /// <remarks/>
        BOOK,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class ServiceLevel8Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType5 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType5 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(ServiceLevel8Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType5));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current ServiceLevel8Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an ServiceLevel8Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ServiceLevel8Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ServiceLevel8Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ServiceLevel8Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ServiceLevel8Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ServiceLevel8Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((ServiceLevel8Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ServiceLevel8Choice Deserialize(System.IO.Stream s)
        {
            return ((ServiceLevel8Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ServiceLevel8Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ServiceLevel8Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ServiceLevel8Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ServiceLevel8Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ServiceLevel8Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ServiceLevel8Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ServiceLevel8Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType5
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class LocalInstrument2Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType6 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType6 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(LocalInstrument2Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType6));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current LocalInstrument2Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an LocalInstrument2Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output LocalInstrument2Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out LocalInstrument2Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(LocalInstrument2Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out LocalInstrument2Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static LocalInstrument2Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((LocalInstrument2Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static LocalInstrument2Choice Deserialize(System.IO.Stream s)
        {
            return ((LocalInstrument2Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current LocalInstrument2Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an LocalInstrument2Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output LocalInstrument2Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out LocalInstrument2Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(LocalInstrument2Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out LocalInstrument2Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static LocalInstrument2Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType6
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class CategoryPurpose1Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType7 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType7 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(CategoryPurpose1Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType7));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CategoryPurpose1Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an CategoryPurpose1Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CategoryPurpose1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CategoryPurpose1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CategoryPurpose1Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out CategoryPurpose1Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static CategoryPurpose1Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CategoryPurpose1Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CategoryPurpose1Choice Deserialize(System.IO.Stream s)
        {
            return ((CategoryPurpose1Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current CategoryPurpose1Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an CategoryPurpose1Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output CategoryPurpose1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out CategoryPurpose1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CategoryPurpose1Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out CategoryPurpose1Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static CategoryPurpose1Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType7
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum Priority3Code
    {

        /// <remarks/>
        URGT,

        /// <remarks/>
        HIGH,

        /// <remarks/>
        NORM,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum ChargeBearerType1Code
    {

        /// <remarks/>
        DEBT,

        /// <remarks/>
        CRED,

        /// <remarks/>
        SHAR,

        /// <remarks/>
        SLEV,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class CashAccount24
    {

        #region Private fields
        private AccountIdentification4Choice _id;

        private CashAccountType2Choice _tp;

        private string _ccy;

        private string _nm;

        private static XmlSerializer serializer;
        #endregion

        public AccountIdentification4Choice Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public CashAccountType2Choice Tp
        {
            get
            {
                return this._tp;
            }
            set
            {
                this._tp = value;
            }
        }

        public string Ccy
        {
            get
            {
                return this._ccy;
            }
            set
            {
                this._ccy = value;
            }
        }

        public string Nm
        {
            get
            {
                return this._nm;
            }
            set
            {
                this._nm = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(CashAccount24));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Id should be serialized
        /// </summary>
        public virtual bool ShouldSerializeId()
        {
            return (_id != null);
        }

        /// <summary>
        /// Test whether Tp should be serialized
        /// </summary>
        public virtual bool ShouldSerializeTp()
        {
            return (_tp != null);
        }

        /// <summary>
        /// Test whether Ccy should be serialized
        /// </summary>
        public virtual bool ShouldSerializeCcy()
        {
            return !string.IsNullOrEmpty(Ccy);
        }

        /// <summary>
        /// Test whether Nm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeNm()
        {
            return !string.IsNullOrEmpty(Nm);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CashAccount24 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an CashAccount24 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CashAccount24 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CashAccount24 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CashAccount24);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out CashAccount24 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static CashAccount24 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CashAccount24)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CashAccount24 Deserialize(System.IO.Stream s)
        {
            return ((CashAccount24)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current CashAccount24 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an CashAccount24 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output CashAccount24 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out CashAccount24 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CashAccount24);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out CashAccount24 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static CashAccount24 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class AccountIdentification4Choice
    {

        #region Private fields
        private bool _shouldSerializeItem;

        private object _item;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("IBAN", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Othr", typeof(GenericAccountIdentification1))]
        public object Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
                _shouldSerializeItem = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(AccountIdentification4Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            if (_shouldSerializeItem)
            {
                return true;
            }
            return (_item != default(object));
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current AccountIdentification4Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an AccountIdentification4Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output AccountIdentification4Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out AccountIdentification4Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(AccountIdentification4Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out AccountIdentification4Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static AccountIdentification4Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((AccountIdentification4Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static AccountIdentification4Choice Deserialize(System.IO.Stream s)
        {
            return ((AccountIdentification4Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current AccountIdentification4Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an AccountIdentification4Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output AccountIdentification4Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out AccountIdentification4Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(AccountIdentification4Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out AccountIdentification4Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static AccountIdentification4Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class GenericAccountIdentification1
    {

        #region Private fields
        private string _id;

        private AccountSchemeName1Choice _schmeNm;

        private string _issr;

        private static XmlSerializer serializer;
        #endregion

        public string Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public AccountSchemeName1Choice SchmeNm
        {
            get
            {
                return this._schmeNm;
            }
            set
            {
                this._schmeNm = value;
            }
        }

        public string Issr
        {
            get
            {
                return this._issr;
            }
            set
            {
                this._issr = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(GenericAccountIdentification1));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether SchmeNm should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSchmeNm()
        {
            return (_schmeNm != null);
        }

        /// <summary>
        /// Test whether Id should be serialized
        /// </summary>
        public virtual bool ShouldSerializeId()
        {
            return !string.IsNullOrEmpty(Id);
        }

        /// <summary>
        /// Test whether Issr should be serialized
        /// </summary>
        public virtual bool ShouldSerializeIssr()
        {
            return !string.IsNullOrEmpty(Issr);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current GenericAccountIdentification1 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an GenericAccountIdentification1 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output GenericAccountIdentification1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out GenericAccountIdentification1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GenericAccountIdentification1);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out GenericAccountIdentification1 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static GenericAccountIdentification1 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((GenericAccountIdentification1)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static GenericAccountIdentification1 Deserialize(System.IO.Stream s)
        {
            return ((GenericAccountIdentification1)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current GenericAccountIdentification1 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an GenericAccountIdentification1 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output GenericAccountIdentification1 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out GenericAccountIdentification1 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(GenericAccountIdentification1);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out GenericAccountIdentification1 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static GenericAccountIdentification1 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class AccountSchemeName1Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(AccountSchemeName1Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current AccountSchemeName1Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an AccountSchemeName1Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output AccountSchemeName1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out AccountSchemeName1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(AccountSchemeName1Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out AccountSchemeName1Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static AccountSchemeName1Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((AccountSchemeName1Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static AccountSchemeName1Choice Deserialize(System.IO.Stream s)
        {
            return ((AccountSchemeName1Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current AccountSchemeName1Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an AccountSchemeName1Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output AccountSchemeName1Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out AccountSchemeName1Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(AccountSchemeName1Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out AccountSchemeName1Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static AccountSchemeName1Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class CashAccountType2Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType1 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType1 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(CashAccountType2Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType1));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CashAccountType2Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an CashAccountType2Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output CashAccountType2Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out CashAccountType2Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CashAccountType2Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out CashAccountType2Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static CashAccountType2Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((CashAccountType2Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static CashAccountType2Choice Deserialize(System.IO.Stream s)
        {
            return ((CashAccountType2Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current CashAccountType2Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an CashAccountType2Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output CashAccountType2Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out CashAccountType2Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(CashAccountType2Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out CashAccountType2Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static CashAccountType2Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType1
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class ClearingSystemIdentification3Choice
    {

        #region Private fields
        private bool _shouldSerializeItemElementName;

        private string _item;

        private ItemChoiceType2 _itemElementName;

        private static XmlSerializer serializer;
        #endregion

        [System.Xml.Serialization.XmlElementAttribute("Cd")]
        [System.Xml.Serialization.XmlElementAttribute("Prtry")]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
        public string Item
        {
            get
            {
                return this._item;
            }
            set
            {
                this._item = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemChoiceType2 ItemElementName
        {
            get
            {
                return this._itemElementName;
            }
            set
            {
                this._itemElementName = value;
                _shouldSerializeItemElementName = true;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(ClearingSystemIdentification3Choice));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether ItemElementName should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItemElementName()
        {
            if (_shouldSerializeItemElementName)
            {
                return true;
            }
            return (_itemElementName != default(ItemChoiceType2));
        }

        /// <summary>
        /// Test whether Item should be serialized
        /// </summary>
        public virtual bool ShouldSerializeItem()
        {
            return !string.IsNullOrEmpty(Item);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current ClearingSystemIdentification3Choice object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an ClearingSystemIdentification3Choice object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output ClearingSystemIdentification3Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out ClearingSystemIdentification3Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ClearingSystemIdentification3Choice);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out ClearingSystemIdentification3Choice obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static ClearingSystemIdentification3Choice Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((ClearingSystemIdentification3Choice)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static ClearingSystemIdentification3Choice Deserialize(System.IO.Stream s)
        {
            return ((ClearingSystemIdentification3Choice)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current ClearingSystemIdentification3Choice object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an ClearingSystemIdentification3Choice object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output ClearingSystemIdentification3Choice object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out ClearingSystemIdentification3Choice obj, out System.Exception exception)
        {
            exception = null;
            obj = default(ClearingSystemIdentification3Choice);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out ClearingSystemIdentification3Choice obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static ClearingSystemIdentification3Choice LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07", IncludeInSchema = false)]
    public enum ItemChoiceType2
    {

        /// <remarks/>
        Cd,

        /// <remarks/>
        Prtry,
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public class SettlementInstruction4
    {

        #region Private fields
        private bool _shouldSerializeSttlmMtd;

        private SettlementMethod1Code _sttlmMtd;

        private CashAccount24 _sttlmAcct;

        private ClearingSystemIdentification3Choice _clrSys;

        private BranchAndFinancialInstitutionIdentification5 _instgRmbrsmntAgt;

        private CashAccount24 _instgRmbrsmntAgtAcct;

        private BranchAndFinancialInstitutionIdentification5 _instdRmbrsmntAgt;

        private CashAccount24 _instdRmbrsmntAgtAcct;

        private BranchAndFinancialInstitutionIdentification5 _thrdRmbrsmntAgt;

        private CashAccount24 _thrdRmbrsmntAgtAcct;

        private static XmlSerializer serializer;
        #endregion

        public SettlementMethod1Code SttlmMtd
        {
            get
            {
                return this._sttlmMtd;
            }
            set
            {
                this._sttlmMtd = value;
                _shouldSerializeSttlmMtd = true;
            }
        }

        public CashAccount24 SttlmAcct
        {
            get
            {
                return this._sttlmAcct;
            }
            set
            {
                this._sttlmAcct = value;
            }
        }

        public ClearingSystemIdentification3Choice ClrSys
        {
            get
            {
                return this._clrSys;
            }
            set
            {
                this._clrSys = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 InstgRmbrsmntAgt
        {
            get
            {
                return this._instgRmbrsmntAgt;
            }
            set
            {
                this._instgRmbrsmntAgt = value;
            }
        }

        public CashAccount24 InstgRmbrsmntAgtAcct
        {
            get
            {
                return this._instgRmbrsmntAgtAcct;
            }
            set
            {
                this._instgRmbrsmntAgtAcct = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 InstdRmbrsmntAgt
        {
            get
            {
                return this._instdRmbrsmntAgt;
            }
            set
            {
                this._instdRmbrsmntAgt = value;
            }
        }

        public CashAccount24 InstdRmbrsmntAgtAcct
        {
            get
            {
                return this._instdRmbrsmntAgtAcct;
            }
            set
            {
                this._instdRmbrsmntAgtAcct = value;
            }
        }

        public BranchAndFinancialInstitutionIdentification5 ThrdRmbrsmntAgt
        {
            get
            {
                return this._thrdRmbrsmntAgt;
            }
            set
            {
                this._thrdRmbrsmntAgt = value;
            }
        }

        public CashAccount24 ThrdRmbrsmntAgtAcct
        {
            get
            {
                return this._thrdRmbrsmntAgtAcct;
            }
            set
            {
                this._thrdRmbrsmntAgtAcct = value;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializerFactory().CreateSerializer(typeof(SettlementInstruction4));
                }
                return serializer;
            }
        }

        /// <summary>
        /// Test whether SttlmMtd should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSttlmMtd()
        {
            if (_shouldSerializeSttlmMtd)
            {
                return true;
            }
            return (_sttlmMtd != default(SettlementMethod1Code));
        }

        /// <summary>
        /// Test whether SttlmAcct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeSttlmAcct()
        {
            return (_sttlmAcct != null);
        }

        /// <summary>
        /// Test whether ClrSys should be serialized
        /// </summary>
        public virtual bool ShouldSerializeClrSys()
        {
            return (_clrSys != null);
        }

        /// <summary>
        /// Test whether InstgRmbrsmntAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstgRmbrsmntAgt()
        {
            return (_instgRmbrsmntAgt != null);
        }

        /// <summary>
        /// Test whether InstgRmbrsmntAgtAcct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstgRmbrsmntAgtAcct()
        {
            return (_instgRmbrsmntAgtAcct != null);
        }

        /// <summary>
        /// Test whether InstdRmbrsmntAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstdRmbrsmntAgt()
        {
            return (_instdRmbrsmntAgt != null);
        }

        /// <summary>
        /// Test whether InstdRmbrsmntAgtAcct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeInstdRmbrsmntAgtAcct()
        {
            return (_instdRmbrsmntAgtAcct != null);
        }

        /// <summary>
        /// Test whether ThrdRmbrsmntAgt should be serialized
        /// </summary>
        public virtual bool ShouldSerializeThrdRmbrsmntAgt()
        {
            return (_thrdRmbrsmntAgt != null);
        }

        /// <summary>
        /// Test whether ThrdRmbrsmntAgtAcct should be serialized
        /// </summary>
        public virtual bool ShouldSerializeThrdRmbrsmntAgtAcct()
        {
            return (_thrdRmbrsmntAgtAcct != null);
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current SettlementInstruction4 object into an XML string
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
                System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
                Serializer.Serialize(xmlWriter, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an SettlementInstruction4 object
        /// </summary>
        /// <param name="input">string workflow markup to deserialize</param>
        /// <param name="obj">Output SettlementInstruction4 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string input, out SettlementInstruction4 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(SettlementInstruction4);
            try
            {
                obj = Deserialize(input);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string input, out SettlementInstruction4 obj)
        {
            System.Exception exception = null;
            return Deserialize(input, out obj, out exception);
        }

        public static SettlementInstruction4 Deserialize(string input)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(input);
                return ((SettlementInstruction4)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static SettlementInstruction4 Deserialize(System.IO.Stream s)
        {
            return ((SettlementInstruction4)(Serializer.Deserialize(s)));
        }
        #endregion

        /// <summary>
        /// Serializes current SettlementInstruction4 object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an SettlementInstruction4 object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output SettlementInstruction4 object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out SettlementInstruction4 obj, out System.Exception exception)
        {
            exception = null;
            obj = default(SettlementInstruction4);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out SettlementInstruction4 obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static SettlementInstruction4 LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:iso:std:iso:20022:tech:xsd:pacs.008.001.07")]
    public enum SettlementMethod1Code
    {

        /// <remarks/>
        INDA,

        /// <remarks/>
        INGA,

        /// <remarks/>
        COVE,

        /// <remarks/>
        CLRG,
    }
}
#pragma warning restore
