using Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Infra.Repositories
{
    public class ProdutoMap
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<Produto>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdField(x => x.Id);
                map.MapIdField(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.CategoriaId).SetIsRequired(true);
                map.MapMember(x => x.Preco).SetIsRequired(true);
                map.MapMember(x => x.Descricao).SetIsRequired(false);
                map.MapMember(x => x.Foto).SetIsRequired(false);
            });
        }
    }
}
