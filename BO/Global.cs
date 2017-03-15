using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public static class Global
    {
        #region Fields
        private static int _IDUSUARIO = 0;
        private static int _IDPACIENTE = 0;
        private static int _IDEVOLUCAO = 0;
        private static bool _ABRIU_PESQUISA_PACIENTE = false;
        private static DateTime _AGENDA_DATA = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy ") + "08:00");
        private static int _AGENDA_IDMEDICO = 0;
        //False = Pelo cadastro de paciente
        //True = Pela agenda
        //Armazenar as operações para que não precise buscar do banco a cada mudança de form
        private static bool _OPE_AGENDA = false;
        private static bool _OPE_CID = false;
        private static bool _OPE_CADASTRO_PACIENTE = false;
        private static bool _OPE_PESQUISA_PACIENTE = false;
        private static bool _OPE_EVOLUCAO_PACIENTE = false;
        private static bool _OPE_CIDADE = false;
        private static bool _OPE_USUARIO = false;
        private static bool _OPE_CLINICA = false;
        #endregion

        #region Properties
        public static int IDUSUARIO
        {
            get { return _IDUSUARIO; }
            set { _IDUSUARIO = value; }
        }

        public static int IDPACIENTE
        {
            get { return _IDPACIENTE; }
            set { _IDPACIENTE = value; }
        }

        public static int IDEVOLUCAO
        {
            get { return _IDEVOLUCAO; }
            set { _IDEVOLUCAO = value; }
        }

        public static bool ABRIU_PESQUISA_PACIENTE
        {
            get { return _ABRIU_PESQUISA_PACIENTE; }
            set { _ABRIU_PESQUISA_PACIENTE = value; }
        }

        public static DateTime AGENDA_DATA
        {
            get { return _AGENDA_DATA; }
            set { _AGENDA_DATA = value; }
        }

        public static int AGENDA_IDMEDICO
        {
            get { return _AGENDA_IDMEDICO; }
            set { _AGENDA_IDMEDICO = value; }
        }

        public static bool OPE_AGENDA
        {
            get { return _OPE_AGENDA; }
            set { _OPE_AGENDA = value; }
        }

        public static bool OPE_CID
        {
            get { return _OPE_CID; }
            set { _OPE_CID = value; }
        }

        public static bool OPE_CADASTRO_PACIENTE
        {
            get { return _OPE_CADASTRO_PACIENTE; }
            set { _OPE_CADASTRO_PACIENTE = value; }
        }

        public static bool OPE_PESQUISA_PACIENTE
        {
            get { return _OPE_PESQUISA_PACIENTE; }
            set { _OPE_PESQUISA_PACIENTE = value; }
        }

        public static bool OPE_EVOLUCAO_PACIENTE
        {
            get { return _OPE_EVOLUCAO_PACIENTE; }
            set { _OPE_EVOLUCAO_PACIENTE = value; }
        }

        public static bool OPE_CIDADE
        {
            get { return _OPE_CIDADE; }
            set { _OPE_CIDADE = value; }
        }

        public static bool OPE_USUARIO
        {
            get { return _OPE_USUARIO; }
            set { _OPE_USUARIO = value; }
        }

        public static bool OPE_CLINICA
        {
            get { return _OPE_CLINICA; }
            set { _OPE_CLINICA = value; }
        }
        #endregion
    }
}
