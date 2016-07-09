export class AccessTokenModel
{
	public username: string;
	public password: string;
	public persistent: boolean;
}

export class RefreshTokenModel
{
	public refreshToken: string;
}