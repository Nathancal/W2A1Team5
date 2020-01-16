using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web2Ass1Team5.App_Code.DAL;

namespace Web2Ass1Team5.App_Code.BLL
{
    public class ProductRating
    {
        private int ratingId, productId, rating, userId;
        private string ratingDesc;
        private DateTime dateSubmitted;

        public ProductRating(int productId, int rating, int userId, string ratingDesc)
        {
            this.productId = productId;
            this.rating = rating;
            this.userId = userId;
            this.ratingDesc = ratingDesc;

        }

        public ProductRating(int productId, int rating, int userId, string ratingDesc, DateTime dateSub)
        {
            this.productId = productId;
            this.rating = rating;
            this.userId = userId;
            this.ratingDesc = ratingDesc;

        }


        public ProductRating(int ratingId, int productId, int rating, int userId, string ratingDesc, DateTime dateSub)
        {
            this.ratingId = ratingId;
            this.productId = productId;
            this.rating = rating;
            this.userId = userId;
            this.ratingDesc = ratingDesc;
            this.dateSubmitted = dateSub;

        }

        public ProductRating() { }

        public static DataSet getRatingsForProduct(int productId)
        {
            return daProductRating.getRatingsForProduct(productId);
        }

        public static DataSet getLatestRatings() {
            return daProductRating.getLatestRatings();
        }

        public ProductRating createRating(int productId, int rating, int userId, string ratingDesc)
        {
            ProductRating returnRating = daProductRating.createNewRating(productId, rating, userId, ratingDesc);
            return returnRating;
        }

        public ProductRating updateRating(int ratingId, int rating, string ratingDesc)
        {
            ProductRating updateRating = daProductRating.updateRating(ratingId, rating, ratingDesc);

            return updateRating;
        }

        public ProductRating returnRating(int productId, int userId)
        {
            ProductRating returnRating = daProductRating.returnRating(productId, userId);

            return returnRating;
        }

        public int getRating()
        {
            return rating;
        }

        public int getProductId()
        {
            return productId;
        }

        public string getRatingDesc()
        {
            return ratingDesc;
        }

        public DateTime getDateSubmitted()
        {
            return dateSubmitted;
        }



        public int getUserId()
        {
            return userId;
        }

        public void setRating(int rating)
        {
            this.rating = rating;

        }

        public void setProductId(int productId)
        {
            this.productId = productId;

        }

        public void setUserId(int userId)
        {
            this.userId = userId;
        }

        public void setDateSubmitted(DateTime dateSub)
        {
            this.dateSubmitted = dateSub;

        }

        public void setRatingDescription(string ratingDesc)
        {
            this.ratingDesc = ratingDesc;

        }

        public void setRatingId(int ratingId)
        {
            this.ratingId = ratingId;

        }
    }
}