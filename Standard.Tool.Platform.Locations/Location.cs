using System;
using System.ComponentModel;

namespace Standard.Tool.Platform.Locations
{
    public class Location
    {
        [Description("���")]
        public int No { get; set; }


        [Description("�Ƿ�ѡ��")]
        public bool IsSelected { get; set; }

        [Description("����")]
        public string CodeEmpl { get; set; }

        [Description("����")]
        public string LibEmpl { get; set; }

        public string EntitesStockees { get; set; }

        [Description("������: --ɢ����û�� 0")]   
        public string NbEntites { get; set; }
        
        [Description("�洢����: ɢ����û�� ''")]
        public string TypEntites { get; set; }
       
        public string CapaTotaleEnP1 { get; set; }
        
        public string CapaRestanteEnP1 { get; set; }
        
        public string CapaReserveeEnP1 { get; set; } = "0";

        [Description("�Ƿ�ɢ��")]
        public string StockMasse { get; set; }

        [Description("���")]
        public string ChambreFroide { get; set; }

        [Description("��ȫ")]
        public string Stupefiant { get; set; }
        //'0', �߶�
        public string HauteurSol { get; set; }
        //' ', �б�
        public string Liste { get; set; } = " ";
        //'Y', λ��ǩ��
        public string Affectable { get; set; }
        //'100', ����Լ�� --ɢ����û��   -1
        public string MasseMax { get; set; }
        //'100', �߶����� --ɢ����û��    -1  
        public string HautMax { get; set; }
        //'Y', ������     --ɢ����û�� N
        public string MonoLot { get; set; }

        //'N')״̬ N���� 
        public string Type { get; set; } = "N";
    }
}
