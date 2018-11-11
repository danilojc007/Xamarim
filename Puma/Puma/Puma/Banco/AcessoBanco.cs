using System.Collections.Generic;
using SQLite;
using Puma.Modelo;
using Xamarin.Forms;
using Puma.ModelosBanco;

namespace Puma.Banco
{
    public class AcessoBanco
    {
        private SQLiteConnection _conexao;

        public AcessoBanco()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.GetPath("database.sqlite");
            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Relatorios>();
            _conexao.CreateTable<Setores>();
            _conexao.CreateTable<Subitemsetor>();
            _conexao.CreateTable<ItemSubItem>();
            _conexao.CreateTable<DetalhesItem>();
            _conexao.CreateTable<Emails>();

        }
        public void CriarRelatorio(Relatorios relatorio)
        {
            _conexao.Insert(relatorio);
        }
        public void UpdateRelatorio(Relatorios relatorio)
        {
            _conexao.Update(relatorio);
        }
        public Relatorios GetRelatorio(int IdRelatorio)
        {
            return _conexao.Table<Relatorios>().Where(a => a.Id == IdRelatorio).FirstOrDefault();
        }
        public void DeleteRelatorio(Relatorios relatorio)
        {
            int idRelatorio = relatorio.Id;
            List<Setores> relSetor = this.GetSetoresRelatorio(idRelatorio);
            //List<Subitemsetor> relaSubItemSetor = _conexao.Table<Subitemsetor>().Where(a => a.Idrelatorio == idRelatorio).ToList();
            List<ItemSubItem> itemSubItems = _conexao.Table<ItemSubItem>().Where(a => a.RelatoriosId == idRelatorio).ToList();
            List<DetalhesItem> detalhesItems = _conexao.Table<DetalhesItem>().Where(a => a.Idrelatorio == idRelatorio).ToList();

            for (var i = 0; i < detalhesItems.Count; i++)
            {
                _conexao.Delete(detalhesItems[i]);
            }
            for (var i = 0; i < itemSubItems.Count; i++)
            {
                _conexao.Delete(itemSubItems[i]);
            }
            //for (var i = 0; i < relaSubItemSetor.Count; i++)
            //{
            //    _conexao.Delete(relaSubItemSetor[i]);
            //}
            for (var i = 0; i < relSetor.Count; i++)
            {
                //_conexao.Delete(relSetor[i]);
                _conexao.Execute("DELETE FROM Setores WHERE Idrelatorio == ?", relSetor[i].Idrelatorio);
            }
            _conexao.Delete(relatorio);
        }
        public List<Relatorios> GetRelatorios()
        {
            return _conexao.Table<Relatorios>().ToList();
        }

        public List<Setores> GetSetoresRelatorio(int IdRelatorio)
        {
            return _conexao.Table<Setores>().Where(a => a.Idrelatorio == IdRelatorio).ToList();
        }
        public void CriaSetor(Setores setor)
        {
            _conexao.Insert(setor);
        }
        public List<Subitemsetor> GetListSubitemSetor(int IdRelatorio, int IdSetor)
        {
            return _conexao.Table<Subitemsetor>().Where(a => a.Idrelatorio == IdRelatorio && a.Idsetor == IdSetor).ToList();
        }
        public Subitemsetor GetSubItemSetor(int IdRelatorio, int IdSetor, int Id)
        {
            return _conexao.Table<Subitemsetor>().Where(a => a.Idrelatorio == IdRelatorio && a.Idsetor == IdSetor && a.Id == Id).FirstOrDefault();
        }
        public void CreateSubItemSetor(Subitemsetor subItemSetor)
        {
            _conexao.Insert(subItemSetor);
        }
        public List<ItemSubItem> GetListItemsSubItem(Subitemsetor subItemSetor)
        {
            return _conexao.Table<ItemSubItem>().Where(a => a.RelatoriosId == subItemSetor.Idrelatorio && a.Idsetor == subItemSetor.Idsetor && a.Idsubitem == subItemSetor.Id).ToList();
        }
        public ItemSubItem GetItemsSubItem(Subitemsetor subItemSetor)
        {
            return _conexao.Table<ItemSubItem>().Where(a => a.RelatoriosId == subItemSetor.Idrelatorio && a.Idsetor == subItemSetor.Idsetor && a.Id == subItemSetor.Id).FirstOrDefault();
        }
        public void CreateItemSubItem(ItemSubItem itemSub)
        {
            _conexao.Insert(itemSub);
        }
        public List<DetalhesItem> GetDetalhesItems(ItemSubItem itemSub)
        {
            return _conexao.Table<DetalhesItem>().Where(a => a.Idrelatorio == itemSub.RelatoriosId && a.Idsetor == itemSub.Idsetor && a.Idsubitem == itemSub.Idsubitem && a.Iditemsubitem == itemSub.Id).ToList();
        }
        public void CreateDetalheItem(DetalhesItem item)
        {
            _conexao.Insert(item);
        }
        public void UpdateDetalheItem(DetalhesItem item)
        {
            _conexao.Insert(item);
        }
        public void CadastroEmail(Email email)
        {

        }
    }
}
