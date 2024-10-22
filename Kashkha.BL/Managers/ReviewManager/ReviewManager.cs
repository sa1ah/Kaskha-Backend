using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public class ReviewManager : IReviewManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public ReviewManager(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}
        public void Add(Review review)
		{
			_unitOfWork._reviewRepository.Add(review);
			_unitOfWork.Complete();
		}

		public int? Delete(Review review,string userId)
		{
			if (review.UserId != userId)
				return null;
			_unitOfWork._reviewRepository.Delete(review);
			return _unitOfWork.Complete();
		}

		public int? Update(ReviewUpdateDto reviewDto)
		{
			var review = _unitOfWork._reviewRepository.GetFirstOrDefault(reviewDto.ReviewId);
			if (review != null)
			{
				review.UserComment=reviewDto.userComment;
				return _unitOfWork.Complete();
			}
			else
			{
				return null;
			}
	
		}

		public Review GetById(int id)
		{
			return _unitOfWork._reviewRepository.GetFirstOrDefault(id);
		}

		
	}
}
