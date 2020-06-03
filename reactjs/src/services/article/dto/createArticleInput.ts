export interface CreateArticleInput {
    title: string;
    contents: string;
    isActive: boolean;
    authorId: number;
    categoryId: number;
}