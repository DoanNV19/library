import { Author } from './author.model';

export interface Book {
  id: string;
  name: string | null;
  description: string | null;
  authorId: string;
  page: number;
  price: number;
  author: Author | null;
  createdOn: string;
  status: number;
}
