export class UserProfile {
  id!: number;
  firstName!: string;
  lastName!: string;
  email!: string;
  profilePicture?: string;
  locations!: LocationDto[];
}

export class LocationDto {
  id?: number;
  name!: string;
  images!: string[];
}  