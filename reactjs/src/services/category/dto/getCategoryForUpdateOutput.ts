export interface Category{
    id:number;
    name:string;
    isActive:boolean;
    isDelete:boolean;
    description:string;
}
export interface GetCategoryForUpdateOutput{
    category:Category
}