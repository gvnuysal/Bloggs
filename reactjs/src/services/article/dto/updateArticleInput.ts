export interface UpdateArticleInput {
    title: string;
    contents: string;
    isActive: boolean;
    isDeleted: boolean;
    id: number;
    categoryId: number;
}