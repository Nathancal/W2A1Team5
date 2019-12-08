using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VapeShop.App_Code.DAL;

namespace VapeShop.App_Code.BLL
{
    public class ProductRating
    {
        private int ratingNum, productId, rating, userId;
        private string userIp, ratingDesc;
        private DateTime dateSubmitted;

        public ProductRating(int productId, int rating, int userId, string userIp, string ratingDesc, DateTime dateSub)
        {
            this.productId = productId;
            this.ratingNum = rating;
            this.userId = userId;
            this.userIp = userIp;
            this.ratingDesc = ratingDesc;
            this.dateSubmitted = dateSub;
           
        }

        public ProductRating() { }

        public void createRating() {
            int retRatingNum = daProductRating.createNewRating(productId, rating, userId, userIp, ratingDesc, dateSubmitted);
            ratingNum = retRatingNum;          
        }

        public ProductRating updateRating(int ratingId, int rating, string ratingDesc) {
            ProductRating updateRating = daProductRating.updateRating(ratingId, rating, ratingDesc);

            this.rating = rating;
            this.ratingDesc = ratingDesc;

            return updateRating;
        }


    }
}