export interface Category{
    id:number;
    name:string;
    isActive:boolean;
    isDeleted:boolean;
    description:string;
}
export interface GetCategoryForUpdateOutput{
    category:Category
}