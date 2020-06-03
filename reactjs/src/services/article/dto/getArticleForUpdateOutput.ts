export interface Article {
    id: number;
    isActive: boolean;
    isDeleted: boolean;
    authorId: number;
    categoryId: number;
    title: string;
    contents: string;
}
export interface GetArticleForUpdateOutput {
    article: Article
}