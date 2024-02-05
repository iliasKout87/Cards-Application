using Azure;
using Cards.Application.Contracts.Persistence;
using Cards.Application.Models.Cards;
using Cards.Domain.Entities;
using Cards.Domain.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq.Expressions;

namespace Cards.Persistence.Repositories
{
	public class CardRepository : BaseRepository<Card>, ICardRepository
	{
		public CardRepository(CardsDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<IEnumerable<Card>> GetMemberCardsAsync(Guid userId)
		{
			return await _dbContext.Cards.Where(c => c.UserId == userId).ToListAsync();
		}

		public async Task<Card?> GetMemberCardByIdAsync(Guid userId, Guid cardId)
		{
			return await _dbContext.Cards.FirstOrDefaultAsync(c => c.UserId == userId && c.CardId == cardId);
		}

		public async Task<Card?> GetCardByIdAsync(Guid cardId)
		{
			return await _dbContext.Cards.FirstOrDefaultAsync(c => c.CardId == cardId);
		}

		public async Task<IEnumerable<Card>> GetPagedMemberCardsAsync(Guid userId, string? searchTerm, CardSortColumn sortColumn, string sortOrder, int? page, int? size)
		{
			IQueryable<Card> cardsQuery = _dbContext.Cards.Where(c => c.UserId == userId);

			if (!string.IsNullOrEmpty(searchTerm))
			{
				cardsQuery = cardsQuery.Where(c => c.Name.Contains(searchTerm)
					|| c.Color.Contains(searchTerm)
					|| c.Status.ToString().Contains(searchTerm)
					|| c.CreatedDate.ToString().Contains(searchTerm));
			}

			Expression<Func<Card, object>> keySelector = sortColumn switch
			{
				CardSortColumn.Name => card => card.Name,
				CardSortColumn.Color => card => card.Color,
				CardSortColumn.Status => card => card.Status,
				CardSortColumn.CreateDate => card => card.CreatedDate,
				CardSortColumn.None => card => card.CardId,
				_ => card => card.CardId,
			};

			if (sortOrder?.ToLower() == "desc")
			{
				cardsQuery = cardsQuery.OrderByDescending(keySelector);
			}
			else
			{
				cardsQuery = cardsQuery.OrderBy(keySelector);
			}

			if (page != null && size != null)
			{
				cardsQuery = cardsQuery.Skip((page.Value - 1) * size.Value).Take(size.Value);
			}

			return await cardsQuery.ToListAsync();
		}

		public async Task<int> GetTotalCountOfFilteredMemberCardsAsync(Guid userId, string? searchTerm)
		{
			IQueryable<Card> cardsQuery = _dbContext.Cards.Where(c => c.UserId == userId);

			if (!string.IsNullOrEmpty(searchTerm))
			{
				cardsQuery = cardsQuery.Where(c => c.Name.Contains(searchTerm)
					|| c.Color.Contains(searchTerm)
					|| c.Status.ToString().Contains(searchTerm)
					|| c.CreatedDate.ToString().Contains(searchTerm));
			}

			return await cardsQuery.CountAsync();
		}
	}
}
