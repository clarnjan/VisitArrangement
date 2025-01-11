export class MessageInfo {
    userId!: number;
    userFirstName!: string;
    userLastName!: string;
    userProfilePicture!: string;
    isSentByCurrentUser!: boolean;
    messageText!: string;
}

export class MessageDetails {
    messageText!: string;
    isSentByCurrentUser!: boolean;
    sentOn!: Date;
}

export class UserMessages {
    userId!: number;
    firstName!: string;
    lastName!: string;
    profilePicture!: string;
    messages!: MessageDetails[];
}