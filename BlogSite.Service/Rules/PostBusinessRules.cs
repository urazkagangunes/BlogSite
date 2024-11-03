using BlogSite.Models.Entities;
using Core.Exceptions;

namespace BlogSite.Service.Rules;

public class PostBusinessRules
{
    public virtual void PostIsNullCheck(Post post)
    {
        if (post == null)
        {
            throw new NotFoundException("İlgili post bulunamadı.");
        }
    }
}
