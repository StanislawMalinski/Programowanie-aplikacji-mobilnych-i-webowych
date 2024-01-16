
interface UserProfileProps {
    user: any
}

function UserProfile(props: UserProfileProps) {
    return (
        <>
            <div className="user-profile">
                <h1>{props.user.userName}</h1>
                <h2>{props.user.bio}</h2>
            </div>
        </>
    );
}

export default UserProfile;