
import './MainContent.css'
import { getPhrase } from "./LanguageSelector";

import MainPage from "./main_pages/MainPage";
import ProfilePage from "./main_pages/ProfilePage";
import NewPostPage from "./main_pages/NewPostPage";

interface MainContentProps {
    navigateToProfile(): void;
    state: string

    setSelectedUser: (id: number) => void;
    selectedUser: number;
}

function MainContent(props: MainContentProps) {
    var content
    // console.log(props.state);
    
    switch (props.state) {
        case "main-page":
            content = <MainPage />;
            break;
        case "my-profile":
            content = <ProfilePage />;
            break;
        case "new-post":
            content =  <NewPostPage />
            break;
        case "profile":
            content = <h1>{getPhrase("profile")}</h1>;
            break;
        default:
            content = <h1>{getPhrase("error-message")}</h1>;
            break;
    }

    return (
        <>
            <div className="main-content-frame">
                <div className="main-content">
                    {content}
                </div>
            </div>
        </>
    );
}

export default MainContent;

/*
switch (props.state) {
        case "main-page":
            useEffect(() => {
                GetPosts(page)
                .then((res) => 
                    setPosts(res)
                ).catch((err) =>
                    console.error(err)
                );
                // console.log(page);
            }, [page]);

            useEffect(() => {
                GetMaxPosts()
                .then((res) =>
                    setMaxPages(res)
                ).catch((err) =>
                    console.error(err)
                );
            }, [page]);

            content = <>
                <PostList posts={posts} 
                    navigateToUser={(id) => {
                        setPage(1);
                        props.setSelectedUser(id);
                        props.navigateToProfile();
                    }}/>
                </>;

            break;
        case "my-profile":
            useEffect(() => {
                GetPostsForUser(1, page)
                .then((res) => 
                    setPosts(res)
                ).catch((err) =>
                    console.error(err)
                );
            }, [page]);

            useEffect(() => {
                GetMaxPostsForUser(props.selectedUser)
                .then((res) => 
                    setMaxPages(res)
                ).catch((err) =>
                    console.error(err)
                );
            }, [page]);
            
            content = <>
                <PostList posts={posts} 
                    navigateToUser={(id) => {
                    setPage(1);
                    props.setSelectedUser(id);
                    props.navigateToProfile();
                    }}/>
                </>;

            break;
        case "new-post":
            content = <h1>{getPhrase("new-post")}</h1>;
            break;
        case "profile":
            content = <h1>{getPhrase("profile")}</h1>;
            break;
        default:
            content = <h1>{getPhrase("error-message")}</h1>;
            break;
    }

*/