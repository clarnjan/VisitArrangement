export class UserProfile {
  id!: number;
  firstName!: string;
  lastName!: string;
  email!: string;
  profilePicture?: string;
  rating: number | undefined;
  locations!: LocationDto[];
  visitArranged: boolean = false;
  rated: boolean = false;
  reviews: ReviewDto[] = [];
}

export class LocationDto {
  id?: number;
  name!: string;
  images!: string[];
}  

export class ReviewDto {
  firstName!: string;
  lastName!: string;
  profilePicture!: string;
  rating!: number;
  comment?: string;
}

export class ReviewRequest {
  rating!: number;
  comment?: string;
}